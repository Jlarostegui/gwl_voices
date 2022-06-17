using Castle.MicroKernel.SubSystems.Conversion;
using System.ComponentModel.DataAnnotations;

namespace BackEventos.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

       [Required]
       [StringLength(100)]
       public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public String Start { get; set; }
        [Required]
        public String End { get; set; }
        [Required]
        [StringLength(100)]
        public string Place { get; set; }

    }
}
