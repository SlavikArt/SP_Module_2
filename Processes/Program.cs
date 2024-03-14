using System.Text;
using System.Diagnostics;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Введіть ім'я програми, яку хочете запустити (за замовчуванням - notepad.exe):");
        string programName = Console.ReadLine();

        if (string.IsNullOrEmpty(programName))
            programName = "notepad.exe";

        Process childProcess = new Process();
        childProcess.StartInfo.FileName = programName;

        try
        {
            childProcess.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка при запуску процесу: " + ex.Message);
            return;
        }

        Console.WriteLine("Введіть 1, щоб зачекати завершення процесу, або 2, щоб примусово завершити процес.");
        string input = Console.ReadLine();

        if (input == "1")
        {
            childProcess.WaitForExit();
            Console.WriteLine("Код завершення: " + childProcess.ExitCode);
        }
        else if (input == "2")
        {
            try
            {
                childProcess.Kill();
                Console.WriteLine("Процес було примусово завершено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при завершенні процесу: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Невідома команда: " + input);
        }
    }
}
