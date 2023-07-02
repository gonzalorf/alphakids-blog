﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaKids.Application.Users.Commands.Login
{
    public record LoginCommand(string Email) : IRequest<string>;
}
