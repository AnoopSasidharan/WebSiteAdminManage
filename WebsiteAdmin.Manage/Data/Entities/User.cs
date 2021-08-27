namespace WebsiteAdmin.Manage.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}
