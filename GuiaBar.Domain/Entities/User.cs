using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuiaBar.Domain.Entities 
{
  [Table("application_user")]
  public class User
  {
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("user_name")]
    public string UserName { get; set; }

    [Column("password")]
    public string Password { get; set; }

    [Column("email")]
    public string Email { get; set; }

  }
}