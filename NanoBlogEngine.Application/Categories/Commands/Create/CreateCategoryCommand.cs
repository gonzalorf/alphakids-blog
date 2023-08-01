using NanoBlogEngine.Application.Configuration.Commands;

namespace NanoBlogEngine.Application.Categories.Commands.Create;

public record CreateCategoryCommand(
    string Name
    ) : CommandBase;
