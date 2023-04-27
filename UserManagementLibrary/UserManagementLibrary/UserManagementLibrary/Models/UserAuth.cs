using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementLibrary.Models;

[Table(name: "um_users_auths")]
public class UserAuth: ParentTable
{ 
    public User User { get; set; }
    public byte[] PassHash { get; set; }
    public byte[] PassKey { get; set; }
}