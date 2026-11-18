#nullable enable
using DVLD.WinForms.Common;
using DVLD.WinForms.Shared;
using DVLD.WinForms.Shared.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Administration.ServiceFees
{
    public class ServiceFeesPresenter : BasePresenter<IServiceFeesView>
    {
        private readonly IAdministrationService _administrationService;
        private List<ServiceFeeItemDto> _catalog = [];
        private ServiceFeeItemDto? _selectedItem;
        private bool _isLiveApi;
        private bool _disposed;

        public ServiceFeesPresenter(
            IServiceFeesView view,
            IAdministrationService administrationService,
            AppSession session,
            INavigationService navigationService)
            : base(view, session, navigationService)
        {
            _administrationService = administrationService;

            View.LoadRequested += OnLoadRequested;
            View.FeeSelected += OnFeeSelected;
            View.SaveRequested += OnSaveRequested;
            View.ResetEditorRequested += OnResetEditorRequested;
        }

        private async void OnLoadRequested(object? sender, EventArgs e)
        {
            await LoadFeesAsync();
        }

        private async Task LoadFeesAsync()
        {
            if (_disposed) return;

            View.SetBanner("Loading Fee Schedule", "Fetching application service fees and examination prices...", HeaderBadgeTone.Info);
            try
            {
                var result = await _administrationService.GetAllFeeTypesAsync();
                if (_disposed) return;

                if (result.IsSuccess && result.Data is not null)
                {
                    _catalog = result.Data.Items;
                    _isLiveApi = result.Data.IsFromLiveApi;
                    View.DisplayFees(_catalog);

                    View.SetBanner(
                        _isLiveApi ? "Live Fee Schedule Connected" : "Local DVLD Fee Catalog Active",
                        _isLiveApi
                            ? $"Loaded {_catalog.Count} configurable service and exam fee items from the API."
                            : $"Displaying {_catalog.Count} standard DVLD fee items (backend ApplicationTypes/TestTypes endpoints not active yet; edits persist for this session).",
                        _isLiveApi ? HeaderBadgeTone.Success : HeaderBadgeTone.Warning);
                }
                else
                {
                    View.SetBanner("Unable to Load Fee Schedule", result.Error?.AllMessages ?? "Fee schedule request failed.", HeaderBadgeTone.Danger);
                }
            }
            catch
            {
                if (!_disposed)
                    View.SetBanner("Connection Error", "Unable to retrieve service and exam fee schedules.", HeaderBadgeTone.Danger);
            }
        }

        private void OnFeeSelected(object? sender, (int Id, FeeCategory Category) key)
        {
            if (_disposed) return;

            var match = _catalog.FirstOrDefault(x => x.Id == key.Id && x.Category == key.Category);
            if (match is null) return;

            _selectedItem = match;
            View.PopulateEditor(match);
        }

        private async void OnSaveRequested(object? sender, EventArgs e)
        {
            if (_disposed || _selectedItem is null) return;

            string title = View.FeeTitleInput;
            string description = View.FeeDescriptionInput;
            string feeRaw = View.FeeAmountInput;

            if (string.IsNullOrWhiteSpace(title))
            {
                View.SetBanner("Validation Error", "Display title cannot be empty.", HeaderBadgeTone.Warning);
                return;
            }

            if (!decimal.TryParse(feeRaw, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal parsedFee) || parsedFee < 0m)
            {
                View.SetBanner("Invalid Fee Amount", "Enter a valid non-negative decimal amount (for example 15.00).", HeaderBadgeTone.Warning);
                return;
            }

            View.SetEditorState(hasSelection: true, isDirty: true, isSaving: true, "Saving fee changes…");
            try
            {
                var request = new UpdateServiceFeeRequest
                {
                    Title = title,
                    Description = description,
                    Fees = decimal.Round(parsedFee, 2)
                };

                var response = await _administrationService.UpdateFeeTypeAsync(_selectedItem.Id, _selectedItem.Category, request);
                if (_disposed) return;

                if (response.IsSuccess && response.Data is not null)
                {
                    int idx = _catalog.FindIndex(x => x.Id == _selectedItem.Id && x.Category == _selectedItem.Category);
                    if (idx >= 0)
                        _catalog[idx] = response.Data;
                    _selectedItem = response.Data;

                    View.DisplayFees(_catalog);
                    View.PopulateEditor(response.Data);
                    View.SetBanner(
                        "Fee Updated",
                        $"Saved {response.Data.CodeLabel} ({response.Data.Title}) at {response.Data.Fees:C2}.",
                        HeaderBadgeTone.Success);
                }
                else
                {
                    View.SetEditorState(hasSelection: true, isDirty: true, isSaving: false, "Save failed — review error banner.");
                    View.SetBanner("Save Failed", response.Error?.AllMessages ?? "Unable to update fee entry.", HeaderBadgeTone.Danger);
                }
            }
            catch
            {
                if (!_disposed)
                {
                    View.SetEditorState(hasSelection: true, isDirty: true, isSaving: false, "Connection error while saving.");
                    View.SetBanner("Connection Error", "Unable to save fee changes.", HeaderBadgeTone.Danger);
                }
            }
        }

        private void OnResetEditorRequested(object? sender, EventArgs e)
        {
            if (_disposed || _selectedItem is null) return;
            View.PopulateEditor(_selectedItem);
        }

        public override void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            View.LoadRequested -= OnLoadRequested;
            View.FeeSelected -= OnFeeSelected;
            View.SaveRequested -= OnSaveRequested;
            View.ResetEditorRequested -= OnResetEditorRequested;
        }
    }
}
