using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Core.Entities
{
    public class Cart:BaseEntity
    {      
        public string Name { get; set; }
        public string Detail { get; set; }
        public string ImgUrl { get; set; }
    }
}
