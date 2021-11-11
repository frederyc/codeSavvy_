using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Domain.Models
{
    public class Application
    {
        public int Id { get; set; }
        public Job Job { get; set; }
        public Employee Employee { get; set; }
        public string? Resume { get; set; }     // blob file

        public Application()
        {

        }
    }
}
