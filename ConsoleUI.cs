using System;
using System.Threading;

namespace CybersecurityBot.Display
{
    public class ConsoleUI
    {
        // ─── Colour helpers ───────────────────────────────────────────────────────

        private void SetColour(ConsoleColor fg, ConsoleColor bg = ConsoleColor.Black)
        {
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
        }

        private void ResetColour() => Console.ResetColor();

        // ─── ASCII Logo / Title Screen ────────────────────────────────────────────

        public void DisplayLogo()
        {
            Console.Clear();
            SetColour(ConsoleColor.Cyan);
            Console.WriteLine();
            Console.WriteLine(@"  ╔══════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(@"  ║                                                                  ║");
            Console.WriteLine(@"  ║    ██████╗ ██╗   ██╗██████╗ ███████╗██████╗  ██████╗           ║");
            Console.WriteLine(@"  ║   ██╔════╝ ╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔═══██╗          ║");
            Console.WriteLine(@"  ║   ██║       ╚████╔╝ ██████╔╝█████╗  ██████╔╝██║   ██║          ║");
            Console.WriteLine(@"  ║   ██║        ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗██║   ██║          ║");
            Console.WriteLine(@"  ║   ╚██████╗    ██║   ██████╔╝███████╗██║  ██║╚██████╔╝          ║");
            Console.WriteLine(@"  ║    ╚═════╝    ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝ ╚═════╝           ║");
            Console.WriteLine(@"  ║                                                                  ║");
            Console.WriteLine(@"  ║          🛡  CYBERSECURITY  AWARENESS  BOT  🛡                  ║");
            Console.WriteLine(@"  ║                                                                  ║");
            Console.WriteLine(@"  ╚══════════════════════════════════════════════════════════════════╝");
            ResetColour();

            SetColour(ConsoleColor.DarkCyan);
            Console.WriteLine();
            Console.WriteLine("       [ Keeping you safe in the digital world — one tip at a time ]");
            ResetColour();
            Console.WriteLine();

            Thread.Sleep(1200);
        }

        // ─── Welcome Banner ───────────────────────────────────────────────────────

        public void DisplayWelcomeBanner()
        {
            SetColour(ConsoleColor.Yellow);
            Console.WriteLine("  ┌─────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("  │         Welcome to the Cybersecurity Awareness Chatbot!         │");
            Console.WriteLine("  │     I'm here to help you stay safe online. Let's get started.  │");
            Console.WriteLine("  └─────────────────────────────────────────────────────────────────┘");
            ResetColour();
            Console.WriteLine();
        }

        // ─── Personalised Greeting ────────────────────────────────────────────────

        public void DisplayPersonalisedGreeting(string name)
        {
            Console.WriteLine();
            SetColour(ConsoleColor.Green);
            TypewriterEffect($"  ✔  Nice to meet you, {name}! I'm CyberBot, your digital safety guide.", 25);
            ResetColour();
            Console.WriteLine();
        }

        // ─── Section Divider ──────────────────────────────────────────────────────

        public void DisplaySectionDivider()
        {
            SetColour(ConsoleColor.DarkGray);
            Console.WriteLine("  " + new string('─', 65));
            ResetColour();
        }

        // ─── Prompt ───────────────────────────────────────────────────────────────

        public void Prompt(string message)
        {
            SetColour(ConsoleColor.White);
            Console.Write(message);
            ResetColour();
        }

        // ─── Bot Response ─────────────────────────────────────────────────────────

        public void DisplayBotResponse(string message)
        {
            Console.WriteLine();
            SetColour(ConsoleColor.DarkCyan);
            Console.Write("  [CyberBot]: ");
            ResetColour();
            SetColour(ConsoleColor.Gray);
            TypewriterEffect(message, 18);
            ResetColour();
        }

        // ─── Error Message ────────────────────────────────────────────────────────

        public void DisplayError(string message)
        {
            SetColour(ConsoleColor.Red);
            Console.WriteLine($"\n  ⚠  {message}");
            ResetColour();
        }

        // ─── Farewell ─────────────────────────────────────────────────────────────

        public void DisplayFarewell(string name)
        {
            Console.WriteLine();
            DisplaySectionDivider();
            SetColour(ConsoleColor.Yellow);
            TypewriterEffect($"  Goodbye, {name}! Stay safe out there. Remember: think before you click! 🛡", 25);
            ResetColour();
            DisplaySectionDivider();
            Console.WriteLine();
        }

        // ─── Typewriter Effect ────────────────────────────────────────────────────

        public void TypewriterEffect(string text, int delayMs = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }
    }
}
