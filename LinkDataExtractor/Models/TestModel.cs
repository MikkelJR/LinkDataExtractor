using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkDataExtractor.Models
{
    public class TestModel
    {
        [Required(ErrorMessage = "Please enter a valid url")]
        [Url(ErrorMessage = "Please enter a valid url")]
        public string Url { get; set; }
        public bool Facebook { get; set; }
        public bool Twitter { get; set; }
        public bool Manual { get; set; }
    }
}