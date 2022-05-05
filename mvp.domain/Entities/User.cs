namespace mvp.domain.Entities
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? Active { get; set; }
    }
}
