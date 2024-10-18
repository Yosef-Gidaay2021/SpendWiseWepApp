namespace spendwisebase.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


public class User 
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Preferences { get; set; } // Can store user preferences like currency, theme, etc.

    // Navigation property to track related transactions and goals
    public List<Transaction> Transactions { get; set; }
    public List<Goal> Goals { get; set; }
}