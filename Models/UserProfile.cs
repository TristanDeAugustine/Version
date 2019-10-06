using System;
using System.Collections.Generic;


namespace Capstone_0.Models
{
  public class UserProfileModel
  {
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Id { get; set; }
    public DateTime AccountCreated { get; set; } = DateTime.Now;

    public List<TodoModel> ToDoModels { get; set; } = new List<TodoModel>();

  }
}