using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FAQ_Web_Api_Angular.Models
{
    public class QuestionModel
    {


        public int id { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ0-9. ?! \\-]{2,30}$")]
        public String title { get; set; }
        [Required]
        public String question { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ0-9. ?! \\-]{2,30}$")]
        public string name { get; set; }
        [Required]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ][\w\.-]*[a-zA-Z0-9æÆøØåÅ]@[a-zA-ZæÆøØåÅ][\w\.-]*[a-zA-Z0-9æÆøØåÅ]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$)")]
        public String email { get; set; }

    }
}
