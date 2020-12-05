using CodeClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.ViewModel
{
    public class BlogReadMoreViewModel
    {
        public Diseas Diseas { get; set; }
        public List<Diseas> Diseases { get; set; }
        public BreadCrumbViewModel BreadCrumb { get; set; }
        public List<Clients> Clients { get; set; }

    }
}
