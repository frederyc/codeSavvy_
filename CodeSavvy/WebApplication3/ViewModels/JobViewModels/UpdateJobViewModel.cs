﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSavvy.Domain.Enums;

namespace CodeSavvy.WebUI.ViewModels.JobViewModels
{
    public class UpdateJobViewModel
    {
        public Location Location { get; set; }
        public Position Position { get; set; }
        public Level Level { get; set; }
        public int Salary { get; set; }
        public string MinimumQualifications { get; set; }
        public string PreferredQualifications { get; set; }
        public string Description { get; set; }
    }
}
