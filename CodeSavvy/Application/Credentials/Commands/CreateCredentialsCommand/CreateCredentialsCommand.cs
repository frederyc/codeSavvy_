﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CodeSavvy.Application.Credentials.Commands
{
    public class CreateCredentialsCommand : IRequest<Domain.Models.Credentials>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
