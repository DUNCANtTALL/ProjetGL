namespace ProjetGL.Models
{
    public class Notifications
    {
        public string UserName;
        private DateTime date;
        private string message;

        public Notifications(DateTime date, string message ,string UserName)
        {
            this.date = date;
            this.message = message;
            this.UserName = UserName;
        }

        public DateTime Date { get => date; set => date = value; }
        public string Message { get => message; set => message = value; }
    }
}
