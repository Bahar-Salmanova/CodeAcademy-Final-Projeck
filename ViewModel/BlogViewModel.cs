using CodeClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.ViewModel
{
    public class BlogViewModel
    {
        public List< News> News { get; set; }
        public List<Clients> Clients { get; set; }
        public List<Diseas> Diseas { get; set; }

        public BreadCrumbViewModel BreadCrumb { get; set; }

    }
}
