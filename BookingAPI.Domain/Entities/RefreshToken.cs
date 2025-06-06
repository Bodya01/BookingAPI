namespace BookingAPI.Infrastructure.EF.Models
{
    public sealed class RefreshToken
    {
        public string Id { get; set; }
        public string JwtId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsUsed { get; set; }
        public bool Invalidated { get; set; }
        public Guid UserId { get; set; }
    }
}
