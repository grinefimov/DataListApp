using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Data
    {
        public int ID { get; set; }
        [Required]
        public string Data1 { get; set; }
        [Required]
        public string Data2 { get; set; }
        [Required]
        public string Data3 { get; set; }
        [Required]
        public string Data4 { get; set; }
        [Required]
        public string Data5 { get; set; }
    }
}
