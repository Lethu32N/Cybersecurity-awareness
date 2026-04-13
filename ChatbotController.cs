using System;
using System.Threading;
using CybersecurityBot.Display;
using CybersecurityBot.Responses;
using CybersecurityBot.Audio;
using CybersecurityBot.Validation;

namespace CybersecurityBot.Core
{
    public class ChatbotController
    {
        private string _userName;
        private readonly ResponseEngine _responseEngine;
        private readonly ConsoleUI _consoleUI;
        private readonly InputValidator _validator;
        private readonly VoiceGreeting _voiceGreeting;

        public ChatbotController()
        {
            _responseEngine = new ResponseEngine();
            _consoleUI = new ConsoleUI();
            _validator = new InputValidator();
            _voiceGreeting = new VoiceGreeting();
        }

        public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Step 1: Play voice greeting
            _voiceGreeting.Play();

            // Step 2: Display ASCII logo / title screen
            _consoleUI.DisplayLogo();
            Thread.Sleep(800);

            // Step 3: Welcome banner
            _consoleUI.DisplayWelcomeBanner();

            // Step 4: Get user name and personalise
            _userName = GetUserName();
            _consoleUI.DisplayPersonalisedGreeting(_userName);

            // Step 5: Main chat loop
            RunChatLoop();
        }

        private string GetUserName()
        {
            string name = string.Empty;

            while (true)
            {
                _consoleUI.Prompt("Please enter your name: ");
                string input = Console.ReadLine();

                if (_validator.IsValidName(input))
                {
                    name = input.Trim();
                    break;
                }

                _consoleUI.DisplayError("Name cannot be empty. Please try again.");
            }

            return name;
        }

        private void RunChatLoop()
        {
            _consoleUI.DisplaySectionDivider();
            _consoleUI.TypewriterEffect($"  Hello, {_userName}! You can ask me about cybersecurity topics.", 30);
            _consoleUI.TypewriterEffect("  Type 'help' to see what I can assist with, or 'exit' to quit.", 30);
            _consoleUI.DisplaySectionDivider();

            while (true)
            {
                Console.WriteLine();
                _consoleUI.Prompt($"  [{_userName}]: ");
                string userInput = Console.ReadLine();

                if (!_validator.IsValidInput(userInput))
                {
                    _consoleUI.DisplayBotResponse("I didn\u2019t quite understand that. Could you rephrase?");
                    continue;
                }

                string trimmed = userInput.Trim().ToLower();

                if (trimmed == "exit" || trimmed == "quit" || trimmed == "bye")
                {
                    _consoleUI.DisplayFarewell(_userName);
                    break;
                }

                string response = _responseEngine.GetResponse(trimmed, _userName);
                _consoleUI.DisplayBotResponse(response);
            }
        }
    }
}
