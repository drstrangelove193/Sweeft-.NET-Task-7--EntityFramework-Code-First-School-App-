using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Entities
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public string Course { get; set; } = null!;

        public ICollection<TeacherPupil> TeacherPupils { get; set; } = null!;

    }
}
