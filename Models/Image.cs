using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImage.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdImage { get; set; }
        public string ImageName { get; set; }
        public int? IdStadium { get; set; }

        public Stadium Stadium { get; set; }


    }
}
