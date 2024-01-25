namespace Web.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BaseEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; init; }

    /// <summary>
    /// Дата создания
    /// </summary>
    [Column("create_date")]
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Дата изменения
    /// </summary>
    [Column("modify_date")]
    public DateTime ModifyDate { get; set; }
}