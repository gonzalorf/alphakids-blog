using FluentValidation;

namespace NanoBlogEngine.Domain.Posts;

public class PostValidator : AbstractValidator<Post>
{
    public PostValidator()
    {
        _ = RuleFor(p => p.Title).NotEmpty().MinimumLength(16).MaximumLength(255);
        _ = RuleFor(p => p.Preview).MinimumLength(16);
        _ = RuleFor(p => p.Content).NotEmpty();
        _ = RuleFor(p => p.Categories).Must(c => c.Count > 0);
    }

    public static void ValidatePost(Post post)
    {
        var validator = new PostValidator();
        var validationResult = validator.Validate(post);

        if (!validationResult.IsValid)
        {
            throw new PostInvalidStateException(validationResult.ToString());
        }
    }
}
