using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ngjs1.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}
