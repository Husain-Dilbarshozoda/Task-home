namespace Domain.Models;

public class Requests
{
    public int RequestId { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int FromUserId { get; set; }
    public int ToUserId { get; set; }
    public int RequestedSkillId { get; set; }
    public int OfferedSkillId { get; set; }
}