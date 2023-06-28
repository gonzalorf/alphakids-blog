using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaKids.Application.Posts.Commands.Update
{
    public record UpdatePostRequest(
        string Title
        , string Preview
        , string Content
        );
}
