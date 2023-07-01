using FluentValidation;
using System.Net.Http.Headers;

namespace AlphaKids.Domain.Posts;

public class PostValidator : AbstractValidator<Post>
{
    public PostValidator()
    {
        RuleFor(p => p.Title).NotEmpty().MinimumLength(16).MaximumLength(255);
        RuleFor(p => p.Preview).MinimumLength(16);
        RuleFor(p => p.Content).NotEmpty();
        RuleFor(p => p.Categories).Must(c => c.Count > 0);
    }

    public static void ValidatePost(Post post)
    {
        var validator = new PostValidator();
        var validationResult = validator.Validate(post);

        if (!validationResult.IsValid) throw new PostInvalidStateException(validationResult.ToString());
    }
}
