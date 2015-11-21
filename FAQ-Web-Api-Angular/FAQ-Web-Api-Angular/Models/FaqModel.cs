using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FAQ_Web_Api_Angular.Models
{
    public class Faqs
    {

        public int id { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string question { get; set; }
        [Required]
        public string answer { get; set; }

        public int top { get; set; }


    }
}