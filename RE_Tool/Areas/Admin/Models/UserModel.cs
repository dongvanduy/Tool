namespace RE_Tool.Areas.Admin.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }//quyen
        public string FullName { get; set; }
    }
}