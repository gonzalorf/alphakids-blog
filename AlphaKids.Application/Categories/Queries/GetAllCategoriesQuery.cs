using AlphaKids.Application.Shared.Categories;
using MediatR;

namespace AlphaKids.Application.Categories.Queries;

public record GetAllCategoriesQuery() : IRequest<CategoryDto[]>;
