using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class SosialLinks
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(150)]

        public string FBUrl { get; set; }

        [MaxLength(150)]

        public string TwitterUrl { get; set; }

        [MaxLength(150)]

        public string SkypeUrl { get; set; }

        [MaxLength(150)]

        public string LinkedinUrl { get; set; }

        //[MaxLength(200)]
        //public string Icon { get; set; }

    }
}
