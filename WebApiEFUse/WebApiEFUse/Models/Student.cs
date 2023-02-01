using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEFExample.Models
{
    public class Student : Entity
    {
        public int Age { get; set; }
        public int Roll { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Name { get; set; }=string.Empty;
        public int Class { get; set; }
        public string Section { get; set; }=String.Empty;   
    }
}
