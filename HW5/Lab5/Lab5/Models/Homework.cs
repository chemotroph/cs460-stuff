using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lab5.Models
{
    public class Homework
    {
        [Key]
        public int ID { get; set; }

        [Required, DisplayName("Homework Title: ")]
        [StringLength(128)]
        public string HomeworkTitle { get; set; }


        [Required, DisplayName("Course Number: ")]
        
        public int CourseNumber { get; set; }


        [Required, DisplayName("Department: ")]
        [StringLength(128)]
        public string Department { get; set; }

        [Required, DisplayName("Priority: ")]
        public int Priority { get; set; }

        [Required, DisplayName("Notes ")]
        [StringLength(256)]
        public string Notes { get; set; }


        [Required, DisplayName("Due Date and Time: ")]
        public DateTime DueDate { get; set; }

        

    }
}