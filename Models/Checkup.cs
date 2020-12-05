using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class Checkup
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Price { get; set; }
        public ICollection<CheckupSetting> CheckupSettings { get; set; }

    }
}
