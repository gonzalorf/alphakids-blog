using NanoBlogEngine.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoBlogEngine.Domain.Posts.Events;

public record PostRatedEvent(PostId postId) : DomainEventBase;
