using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Domain.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public Job Job { get; set; }

        public Favorite()
        {

        }
    }
}
