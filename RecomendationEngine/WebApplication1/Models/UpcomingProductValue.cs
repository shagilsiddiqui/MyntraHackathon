using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UpcomingProductValue
    {
        public int numberOfLikes { get; set; }
        public int numberOfComments { get; set; }
        public string imageLink { get; set; }
        public string message { get; set; }
    }
}