using Microsoft.VisualBasic;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Reminders;

class Reminder
{
    public string Title { get; set; }
    public DateOnly Duedate { get; set; }
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] HashDigest = sha256.ComputeHash(Encoding.UTF8.GetBytes(Title + Duedate));
    }
    
}

class ReminderList
{
    public Dictionary<string, Reminder>? Reminders;

    public int AddReminder(Reminder reminder)
    {
        try
        {
            string PlainData = reminder.Title + reminder.DueData.ToString();
            using (SHA256 sha256 = SHA256.Create()) {
                byte[] Digest = sha256.ComputeHash(Encoding.UTF8.GetBytes(PlainData));
            }
            return 0;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Failure exception {ex}");
            return 1;
        }
    }

}