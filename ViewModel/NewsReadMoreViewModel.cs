using CodeClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.ViewModel
{
    public class NewsReadMoreViewModel
    {
        public List<News> News { get; set; }
        public News New{ get; set; }
        public List<Clients> Clients { get; set; }

    }
}
