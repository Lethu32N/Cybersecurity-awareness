# Cybersecurity-awareness[README.md](https://github.com/user-attachments/files/26688449/README.md)
# 🛡 Cybersecurity Awareness Bot

A C# console chatbot that educates users about cybersecurity topics.

---

## Project Structure

```
CybersecurityBot/
│
├── Program.cs                          ← Entry point
│
├── Core/
│   └── ChatbotController.cs           ← Orchestrates the chatbot flow
│
├── Display/
│   └── ConsoleUI.cs                   ← All console output / visual elements
│
├── Responses/
│   └── ResponseEngine.cs              ← Keyword-based response engine
│
├── Validation/
│   └── InputValidator.cs              ← Input validation logic
│
├── Audio/
│   └── VoiceGreeting.cs               ← WAV voice greeting playback
│
├── Assets/
│   └── greeting.wav                   ← (You record and place this file here)
│
└── CybersecurityBot.csproj
```

---

## Features

| # | Feature | Details |
|---|---------|---------|
| 1 | **Voice Greeting** | Plays `Assets/greeting.wav` on startup via `System.Media.SoundPlayer` (Windows) |
| 2 | **ASCII Logo** | Large banner displayed as a title screen |
| 3 | **Text Greeting + User Name** | Asks for name, personalises all responses |
| 4 | **Basic Response System** | Covers passwords, phishing, safe browsing, malware, 2FA, social engineering, encryption, Wi-Fi |
| 5 | **Input Validation** | Rejects empty, whitespace-only, and non-alphabetic input with friendly messages |
| 6 | **Enhanced Console UI** | Coloured text, typewriter effect, borders, dividers, section headers |
| 7 | **Code Structure** | Multiple classes across separate namespaces — nothing dumped in `Program.cs` |

---

## How to Add Your Voice Greeting

1. Record a short audio message, e.g.:
   > *"Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online."*
2. Save it as **`greeting.wav`** (WAV format is required for `System.Media.SoundPlayer`).
3. Place the file in the **`Assets/`** folder inside the project directory.
4. Run the project — audio plays automatically on startup.

> If the file is missing or you are on Linux/macOS, the greeting text is displayed in the console instead.

---

## Running the Project

```bash
# Restore and build
dotnet build

# Run
dotnet run
```

Requires **.NET 8 SDK** or later.

---

## Sample Conversation

```
[You]: what is phishing
[CyberBot]:  PHISHING AWARENESS:

   Phishing is when attackers impersonate trusted organisations...
   ...

[You]: how do I create a strong password?
[CyberBot]:  PASSWORD SAFETY TIPS:
   ...

[You]: exit
[CyberBot]: Goodbye, Alice! Stay safe out there. Remember: think before you click! 🛡
```
