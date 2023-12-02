using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicASPTutorial.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Full Name")]
        public string Name { get; set; }

        [DisplayName("Total Score")]
        [Range(0,100)]
        public int Score { get; set; }
    }
}
