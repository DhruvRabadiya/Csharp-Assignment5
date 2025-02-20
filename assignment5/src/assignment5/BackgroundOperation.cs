public class BackgroundOperation
{
    public async Task WriteToFileAsync(string message)
    {
        await Task.Delay(3000);
        await File.WriteAllTextAsync("tmp.txt", message);
    }
}

public class Kiosk
{
    private BackgroundOperation Bo = new BackgroundOperation();
    public async Task KioskMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Write 'Hello World'");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
            Console.WriteLine("Enter your choice (1, 2, or 3), or 0 to quit:");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {
                await Bo.WriteToFileAsync("Hello World");
                Console.WriteLine("Writing 'Hello World' to the file...\n");
            }
            else if (input == 2)
            {
                var currentDate = DateTime.Now.ToString();
                await Bo.WriteToFileAsync(currentDate);
                Console.WriteLine("Adding current date to the file...\n");
            }
            else if (input == 3)
            {
                var osVersion = Environment.OSVersion.VersionString;
                await Bo.WriteToFileAsync(osVersion);
                Console.WriteLine("Adding os version to the file\n");
            }
            else if (input == 0)
            {
                Console.WriteLine("Exit");
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid option. Please enter 1, 2, 3, or 0 to quit.\n");
            }

        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var kiosk = new Kiosk();
            await kiosk.KioskMenu();
        }
    }
}
