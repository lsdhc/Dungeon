using System.ComponentModel;

class LogManager
{
    public enum LogType
        {
            COMMUN,
            DANGER,
            LUCKY,
        }
    public readonly struct Log
    {
        public string Message { get; init;}

        public LogType Type { get; init;}
    }

    private Queue<Log> LogQueue;

    public LogManager()
    {
        LogQueue = new Queue<Log>(GameSettings.MAX_LOG_AMOUNT);
    }

    private bool IsQueueMax()
    {
        return LogQueue.Count() == GameSettings.MAX_LOG_AMOUNT;
    }

    public void AddCommunLog(String message)
    {
        if(IsQueueMax())LogQueue.Dequeue();
        LogQueue.Enqueue(new Log(){Message = message,Type = LogType.COMMUN});
    }

    public void AddDangerLog(String message)
    {
        if(IsQueueMax())LogQueue.Dequeue();
        LogQueue.Enqueue(new Log(){Message = message,Type = LogType.DANGER});
    }

    public void AddLuckyLog(String message)
    {
        if(IsQueueMax())LogQueue.Dequeue();
        LogQueue.Enqueue(new Log(){Message = message,Type = LogType.LUCKY});
    }

    public IEnumerable<Log> GetLogs()
{
    return LogQueue;
}
}