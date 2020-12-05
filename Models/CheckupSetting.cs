using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CodeClinic.Models
{
    public class CheckupSetting
    {
        public int Id { get; set; }
        
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100)]
        public int CheckupId { get; set; }

       
        public Checkup Checkup { get; set; }
    }
}
