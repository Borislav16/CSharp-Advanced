using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Capacity > Inbox.Count)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            Mail mail = Inbox.FirstOrDefault(m => m.Sender == sender);

            if (mail is not null)
            {
                Inbox.Remove(mail);
                return true;
            }

            return false;
        }

        public int ArchiveInboxMessages()
        {
            Archive.AddRange(Inbox);
            Inbox = new List<Mail>();
            int movedMails = Archive.Count;
            return movedMails;
        }

        public string GetLongestMessage()
        {
            Mail mail = Inbox.MaxBy(m => m.Body);
            return mail.ToString();
        }


        public string InboxView()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Inbox:");
            for (int i = 0; i < Inbox.Count; i++)
            {
                sb.AppendLine($"{Inbox[i].ToString()}");
            }
            return sb.ToString().Trim();
        }
    } 
}
