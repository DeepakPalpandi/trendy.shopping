namespace trendy.shopping.application.ViewModel.CommonModel
{
    public class ResponseModel
    {
        public string Message {  get; set; } = string.Empty;
        public bool Success { get; set; }
        public string UserName { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public string? Token { get; set; }
    }
}
