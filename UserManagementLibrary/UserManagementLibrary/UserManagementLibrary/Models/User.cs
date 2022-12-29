using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserManagementLibrary.Models;

[Table(name: "um_users_auths")]
public class UserAuth: ParentTable
{ 
    public User User { get; set; }
    public byte[] PassHash { get; set; }
    public byte[] PassKey { get; set; }
}

[Table(name: "um_users")]
[Index(nameof(Uid), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(CitizenNo), IsUnique = true)]
[Index(nameof(PassportNo), IsUnique = true)]
public class User : ParentTable
{
    public string Uid { get; set; }

    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }

    public string? ContactNo { get; set; }

    public string? CitizenNo { get; set; }
    public string? PassportNo { get; set; }
    public string? Email { get; set; }
    public Address? Address { get; set; }
    public Gender? Gender { get; set; }

    public string? FullName { get; set; }
    public string? FatherName { get; set; }

    public string? Picture { get; set; }

    public bool PassChangeRequired { get; set; }
    public bool EmailConfirmed { get; set; }
}

[Table(name: "um_addresses")]
public class Address: ParentTable
{
    [Key]
    [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }
    public string? CompleteAddress { get; set; }
    public string? Street { get; set; }
    public string? HouseNo { get; set; }
    public string? NearBy { get; set; }

    public City? City { get; set; }
}

[Table(name: "um_cities")]
public class City: ParentTable
{
    public string Title { get; set; }
    public Country Country { get; set; }
}

[Table(name: "um_countries")]
[Index(nameof(Title), IsUnique = true)]
public class Country: ParentTable
{
    public string Title { get; set; }
}


[Table(name: "um_genders")]
[Index(nameof(Title), IsUnique = true)]
public class Gender: ParentTable
{
    public string Title { get; set; }
}