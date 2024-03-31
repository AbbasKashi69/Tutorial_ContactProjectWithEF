using System.ComponentModel.DataAnnotations;

namespace ContactProjectWithEF.Models.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public required string Name { get; set; }

        public ICollection<Contact>? Contacts { get; set; }
    }
}
