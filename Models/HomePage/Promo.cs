using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models.HomePage
{
    public class Promo
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(150)]
        public string Icon { get; set; }

        [MaxLength(500)]
        public string Desc { get; set; }
    }
}
