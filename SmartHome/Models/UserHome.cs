
namespace SmartHome.Models
{
    public class UserHome
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long HomeId { get; set; }
        public bool IsOwner { get; set; }
    }
}
