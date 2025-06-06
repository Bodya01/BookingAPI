namespace BookingAPI.Application.Models
{
    public sealed class JwtSettings
    {
        public string SecretKey { get; set; }
        public TimeSpan LifeTime { get; set; }
    }
}