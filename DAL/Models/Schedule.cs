using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StartingDate { get; set; }
        [Required]
        public int [] StudyWeekDays { get; set; }
        [Required]
        public int ChapterSessionsNo { get; set; }
    }
}
