using System.ComponentModel.DataAnnotations.Schema;

namespace yorg.Model;

public class Return
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool Status { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public DateTime CreatedAt { get; set; }
}