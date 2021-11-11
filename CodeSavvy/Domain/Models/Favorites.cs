using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Domain.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Job Job { get; set; }

        public Favorite()
        {

        }
    }
}
