using System.ComponentModel.DataAnnotations;

namespace EventRegistrationPortal.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required]
        public string ParticipantName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int EventId { get; set; }

        public Event? Event { get; set; }
    }
}
