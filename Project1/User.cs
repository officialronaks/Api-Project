using System.ComponentModel.DataAnnotations.Schema;

namespace User
{
    [PrimaryKey(nameof(UserId))]
    public class user
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("Location")]
        public string Location { get; set; } = string.Empty;

    }
}
