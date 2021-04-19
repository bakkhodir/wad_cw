using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRater.DAL.DBO
{
    public class Module
    {
        public int Id { get; set; }

        [Required]
        public string ModuleName { get; set; }
        public int LevelOfStudy{ get; set; }
        public virtual ICollection<Tutor> Tutors { get; set; }
    }
}
