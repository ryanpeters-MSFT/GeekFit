using GeekFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekFit.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}