using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Business.ViewModels.Cart
{
    public class CreateCartVM
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string ImgUrl { get; set; }
    }
}
