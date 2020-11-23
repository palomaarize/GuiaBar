using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuiaBar.Domain.Entities 
{
    [Table("application_pub")]
    public class Pub
    {
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("address")]
    public string Address { get; set; }

    [Column("contact")]
    public string Contact { get; set; }

    [Column("evaluation")]
    public decimal Evaluation { get; set; }
    }

}