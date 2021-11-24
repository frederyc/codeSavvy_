﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Domain.Models
{

    /*
     * Move migration from Domain to infrastructure
     * Create or link db
     * Learn more about how to use entity framework
     */

    public class Application
    {
        public int Id { get; set; }

        [Required]
        public Job Job { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public string Resume { get; set; }     // blob file

        public Application()
        {

        }
    }
}
