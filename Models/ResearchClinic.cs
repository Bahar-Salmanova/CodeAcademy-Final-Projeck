using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class ResearchClinic
    {
        public int Id { get; set; }
       [MaxLength(200)]
        public string About { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Desc { get; set; }

        [MaxLength(200)]
        public string PhotoBig { get; set; }

        [MaxLength(200)]
        public string PhotoSmall { get; set; }

        [MaxLength(200)]
        public string PhotoNormal { get; set; }

        [MaxLength(200)]
        public string VideoUrl { get; set; }
    }
}
