using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuiaBar.Domain.Entities
{
    [Table("user_pub_evaluation")]
    public class UserPubEvaluation
    {
    
    [Column("user_id")]
    public long UserId { get; set; }

    [Column("pub_id")]
    public long PubId { get; set; }

    [Column("evaluation")]
    public decimal Evaluation { get; set; }
    }
}