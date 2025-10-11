
namespace TaskEntityFramework.PLL.Helpers
{
    internal class AlertMessages
    {
        public static void Show(string messages)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(messages);
            Console.ForegroundColor = originalColor;
        }
    }
}
