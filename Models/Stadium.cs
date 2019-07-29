using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImage.Models
{
    public class Stadium
    {

        public Stadium()
        {
            Images = new HashSet<Image>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStadium { get; set; }
        public string StadiumName { get; set; }
        public string Type { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
