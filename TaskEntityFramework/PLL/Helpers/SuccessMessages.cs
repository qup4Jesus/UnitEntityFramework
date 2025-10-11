
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace TaskEntityFramework.PLL.Helpers
{
    internal class SuccessMessages
    {
        public static void Show(string messages)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(messages);
            Console.ForegroundColor = originalColor;
        }
    }
}
