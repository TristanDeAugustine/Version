using System;

namespace Version.Models
{
  public class TodoModel
  {

    public int ID { get; set; }
    public int UserProfileModelID { get; set; }
    public UserProfileModel UserProfileModel { get; set; }

    public string Text { get; set; }

    public DateTime AccountCreated { get; set; } = DateTime.Now;
  }
}