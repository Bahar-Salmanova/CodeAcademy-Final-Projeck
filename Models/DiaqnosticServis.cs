﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class DiaqnosticServis
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Desc { get; set; }

        [MaxLength(200)]
        public string Photo { get; set; }
        [NotMapped]
        public IFormFile Upload { get; set; }


        //[MaxLength(200)]
        //public DateTime Date { get; set; }

    }
}
