using System.ComponentModel.DataAnnotations.Schema;

namespace yorg.Model;

public class Review
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public int Rating { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; set; }
    
    public Guid ProductId { get; set; }
    
    public Product Product { get; set; }
    
}