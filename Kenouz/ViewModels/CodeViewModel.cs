namespace Kenouz.ViewModels
{
    public class CodeViewModel
    {
        public string Code { get; set; } = string.Empty;
        public IList<string>? Roles { get; set; }
        public bool IsActive { get; set; }
    }
}
