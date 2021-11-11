using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Domain.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public Credentials Credentials { get; set; }
        public string CompanyName { get; set; }
        public string? Image { get; set; } // Learn about blobs

        public Employer() 
        { 

        }
        
    }
}
