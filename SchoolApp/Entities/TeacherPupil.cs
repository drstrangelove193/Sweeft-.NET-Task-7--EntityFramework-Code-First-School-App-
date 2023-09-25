using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Entities
{
    public class TeacherPupil
    {
        [Key]
        public int TeacherPupilID { get; set; }

        [Required]
        public int TeacherID { get; set; }

        [Required]
        public int PupilID { get; set; }

        public Teacher Teacher { get; set; } = null!;

        public Pupil Pupil { get; set; } = null!;
    }
}
