namespace DVLD.Api.Common
{
    public class ErrorResponse
    {
        public string Title { get; set; } = string.Empty;
        public int Status { get; set; }
        public List<ErrorDetail> Errors { get; set; } = new();

        public string AllMessages =>
            string.Join(Environment.NewLine,
                Errors.Select(e => $"• {e.Message}"));
    }

    public class ErrorDetail
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
