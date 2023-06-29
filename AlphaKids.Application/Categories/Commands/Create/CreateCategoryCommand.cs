using MediatR;

namespace AlphaKids.Application.Categories.Commands.Create;

public record CreateCategoryCommand(
    string Name
    ) : IRequest;