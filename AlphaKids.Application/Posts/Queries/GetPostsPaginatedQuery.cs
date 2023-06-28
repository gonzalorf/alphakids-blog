using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaKids.Application.Posts.Queries
{
    public record GetPostsPaginatedQuery(int page, int pageSize) : IRequest<IList<PostDto>>;
}
