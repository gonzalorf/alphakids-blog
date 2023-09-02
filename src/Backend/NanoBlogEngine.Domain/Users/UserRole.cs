using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NanoBlogEngine.Domain.Users;

public record UserRole()
{
    public string? Name { get; private set; }
    public static UserRole AdministratorRole => new UserRole() { Name = "Administrator"};
    public static UserRole BlogReaderRole => new UserRole() { Name = "BlogReader" };
    public static UserRole CreateFromName(string? name) => new UserRole() { Name = name }; // TODO: validate name
}