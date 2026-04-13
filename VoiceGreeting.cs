using System;
using System.IO;

// ──────────────────────────────────────────────────────────────────────────────
// NOTE: System.Media.SoundPlayer is Windows-only.
// On Linux/macOS the using is wrapped in a conditional compilation block so the
// project still compiles cross-platform.  The voice-greeting feature will only
// play audio when running on Windows.
// ──────────────────────────────────────────────────────────────────────────────

#if WINDOWS
using System.Media;
#endif

namespace CybersecurityBot.Audio
{
    public class VoiceGreeting
    {
        // ─── Properties ───────────────────────────────────────────────────────────

        /// <summary>Path to the WAV greeting file.</summary>
        public string AudioFilePath { get; private set; }

        /// <summary>Name shown in console when audio plays.</summary>
        public string GreetingText { get; private set; }

        // ─── Constructor ──────────────────────────────────────────────────────────

        public VoiceGreeting()
        {
            // Look for the WAV file relative to the executable's directory
            AudioFilePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Assets",
                "greeting.wav");

            GreetingText =
                "Hello! Welcome to the Cybersecurity Awareness Bot. " +
                "I'm here to help you stay safe online.";
        }

        // ─── Play method ──────────────────────────────────────────────────────────

        /// <summary>
        /// Attempts to play the WAV greeting. If the file is missing or the
        /// platform does not support audio, a console message is shown instead.
        /// </summary>
        public void Play()
        {
#if WINDOWS
            try
            {
                if (File.Exists(AudioFilePath))
                {
                    using (SoundPlayer player = new SoundPlayer(AudioFilePath))
                    {
                        player.PlaySync(); // Blocks until audio finishes
                    }
                }
                else
                {
                    ShowAudioFallback();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\n  [Audio] Could not play greeting: {ex.Message}");
                Console.ResetColor();
            }
#else
            ShowAudioFallback();
#endif
        }

        // ─── Fallback ─────────────────────────────────────────────────────────────

        private void ShowAudioFallback()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n  🔊  [Voice Greeting]: " + GreetingText);
            Console.ResetColor();
            System.Threading.Thread.Sleep(600);
        }
    }
}
