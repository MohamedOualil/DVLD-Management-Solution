#nullable enable
using DVLD.WinForms.Shared.Controls;
using System;
using System.Collections.Generic;

namespace DVLD.WinForms.Features.Administration.ServiceFees
{
    public interface IServiceFeesView
    {
        event EventHandler? LoadRequested;
        event EventHandler<(int Id, FeeCategory Category)>? FeeSelected;
        event EventHandler? SaveRequested;
        event EventHandler? ResetEditorRequested;

        string FeeTitleInput { get; }
        string FeeAmountInput { get; }
        string FeeDescriptionInput { get; }

        void DisplayFees(IEnumerable<ServiceFeeItemDto> fees);
        void PopulateEditor(ServiceFeeItemDto item);
        void SetBanner(string title, string description, HeaderBadgeTone tone);
        void SetEditorState(bool hasSelection, bool isDirty, bool isSaving, string hint);
        void DisplayMessage(string message);
    }
}
