using System.Diagnostics;
internal class Program
{
    private static void Main(string[] args)
    {
        var num = new TimerState { Counter = 0 };
        // создаем таймер:
        System.Timers.Timer timer = new System.Timers.Timer(2000);
        timer.Enabled = true;
        timer.Elapsed += StartProcess;
        Console.ReadLine();
        void StartProcess(object obj, System.Timers.ElapsedEventArgs e)
        {
            num.Counter++;
            Process myProc = null;
            if (num.Counter <= 4)
            {
            try
            {
                string strng = "notepad.exe";
                // Чтобы запустить IE, нужно запустить процесс IExplore.exe
                myProc = Process.Start(strng);
                    AllInfoProcess(e);
                    //Console.WriteLine($"Процесс {0}"+", дата и время процесса {0} ", e.SignalTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            }
            else timer.Stop();
        } }
    static void AllInfoProcess(System.Timers.ElapsedEventArgs e)
    {
        string v = null;
        var myProcess = from proc in Process.GetProcesses(".")
                        orderby proc.Id
                        select proc;
        foreach (var p in myProcess)
            if (p.ProcessName == "notepad")
            {
                v = $"Date: {e.SignalTime}, PID: {p.Id}, Name: {p.ProcessName}";
            }
        Console.WriteLine(v);
    }
    class TimerState
    {
        public int Counter;
    }
    }