using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformService.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Cost { get; set; }
    }

    public class Bom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Name { get; set; }

        public int ChildReferenceId { get; set; }
        public ChildReference CurrentChildReference { get; set; }
    }

    public class ChildReference
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Bom> Boms { get; set; }
    }
}
