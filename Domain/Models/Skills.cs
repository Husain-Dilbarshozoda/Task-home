namespace Domain.Models;

public class Skills
{
    public int SkillId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
}