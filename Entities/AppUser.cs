using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Store.Dto;

namespace Store.Entities;

[Table("users")]
public class AppUser
{
    public int Id { get; set; }

    [MinLength(3)]
    public required string UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [EnumDataType(typeof(StatusEnum))]
    public int Status { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    public required byte[] PasswordHash { get; set; }

    public required byte[] PasswordSalt { get; set; }

    // [EnumDataType(typeof(RoleEnum))]
    public int Role { get; set; }
}