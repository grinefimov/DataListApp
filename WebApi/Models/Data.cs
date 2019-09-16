using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Data
    {
        public int ID { get; set; }
        [Required] public string Data1 { get; set; }
        [Required] public string Data2 { get; set; }
        [Required] public string Data3 { get; set; }
        [Required] public string Data4 { get; set; }
        [Required] public string Data5 { get; set; }
    }
}