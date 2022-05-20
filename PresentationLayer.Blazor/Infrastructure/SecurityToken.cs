namespace PresentationLayer.Blazor.Infrastructure
{
    public class SecurityToken
    {
        public string Login { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public DateTime ExpiredAt { get; set; }
    }
}
