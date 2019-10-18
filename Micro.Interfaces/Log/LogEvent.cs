namespace Micro.Interfaces.Log
{
    public class LogEvent
    {
        public LogEvent(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}