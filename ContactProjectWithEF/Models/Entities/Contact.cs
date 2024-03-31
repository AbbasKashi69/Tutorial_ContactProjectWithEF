using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactProjectWithEF.Models.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Unicode]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Unicode]
        public required string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [MaxLength(50)]
        public required string Mobile { get; set; }

        [MaxLength(50)]
        public string? Phone { get; set; }

        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group? Group { get; set; }

    }
}
