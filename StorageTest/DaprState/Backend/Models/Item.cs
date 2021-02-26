using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<SubItem> SubItem { get; set; }
    }
}
