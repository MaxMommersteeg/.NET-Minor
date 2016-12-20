using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendService.Entities.Entities
{
    public class Cursus
    {
        public Cursus()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string CursusCode { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int AmountOfDays { get; set; }

        [Required]
        public int AmountOfCursisten { get; set; }
    }
}