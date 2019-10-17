using System;

namespace Version
{
  public class JournalModel
  {
    public int ID { get; set; }
    public int UserID { get; set; }
    public DateTime AccountCreated { get; set; } = DateTime.Now;
  }
} 