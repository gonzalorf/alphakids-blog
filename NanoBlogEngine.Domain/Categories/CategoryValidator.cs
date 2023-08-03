using NanoBlogEngine.Domain.Posts;
using FluentValidation;

namespace NanoBlogEngine.Domain.Categories;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        _ = RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(24);
    }

    public static void ValidateCategory(Category category)
    {
        var validator = new CategoryValidator();
        var validationResult = validator.Validate(category);

        if (!validationResult.IsValid)
        {
            throw new CategoryInvalidStateException(validationResult.ToString());
        }
    }
}
