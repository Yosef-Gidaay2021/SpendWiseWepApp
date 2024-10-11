namespace spendwisebase.Models;
public class Goal
{
    public int GoalId { get; set; }
    public string Name { get; set; } // e.g., "Save for a car"
    public decimal TargetAmount { get; set; }
    public decimal CurrentAmount { get; set; }
    public DateTime DueDate { get; set; }
    public int UserId { get; set; } // Foreign Key to User

    // Navigation property for User
    public User User { get; set; }
}