namespace ecommerceweb.Website.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public bool Active { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PassWord { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public string? Salt { get; set; }
        public int? RoleId { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Role? Role { get; set; }
    }
}
