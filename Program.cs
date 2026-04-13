using System;
using CybersecurityBot.Core;

namespace CybersecurityBot
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatbotController controller = new ChatbotController();
            controller.Run();
        }
    }
}
