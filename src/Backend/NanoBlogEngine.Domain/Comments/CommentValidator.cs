using FluentValidation;
using NanoBlogEngine.Domain.Posts.Exceptions;

namespace NanoBlogEngine.Domain.Comments;

public class CommentValidator : AbstractValidator<Comment>
{
    public CommentValidator()
    {
        _ = RuleFor(p => p.Content).MinimumLength(5);
    }

    public static void ValidateComment(Comment comment)
    {
        var validator = new CommentValidator();
        var validationResult = validator.Validate(comment);

        if (!validationResult.IsValid)
        {
            throw new CommentInvalidValueException(validationResult.ToString());
        }
    }
}
