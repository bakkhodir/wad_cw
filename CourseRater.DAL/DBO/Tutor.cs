using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRater.DAL.DBO
{
    public class Tutor
    {
        public int Id { get; set; }

        [Required]
        public string  FullName{ get; set; }
        public string OfficeHours { get; set; }

        [Required]
        public string Email { get; set; }
        public int? ModuleName { get; set; }
        public virtual Module Module { get; set; }


    }
}
