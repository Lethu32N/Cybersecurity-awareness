using System;
using System.Collections.Generic;

namespace CybersecurityBot.Responses
{
    public class ResponseEngine
    {
        // ─── Topic keyword maps ───────────────────────────────────────────────────

        private readonly Dictionary<string[], string> _responses;

        public ResponseEngine()
        {
            _responses = BuildResponseDictionary();
        }

        private Dictionary<string[], string> BuildResponseDictionary()
        {
            return new Dictionary<string[], string>(new KeyArrayComparer())
            {
                // Greetings / small talk
                {
                    new[] { "how are you", "how are u", "how r you" },
                    "I'm doing great, thanks for asking! I'm always on guard — just like a good firewall. How can I help YOU stay secure today?"
                },
                {
                    new[] { "what is your purpose", "what do you do", "why are you here", "what can you do" },
                    "My purpose is to raise cybersecurity awareness! I can help you learn about:\n\n" +
                    "   • Password safety\n" +
                    "   • Phishing scams\n" +
                    "   • Safe browsing habits\n" +
                    "   • Malware & viruses\n" +
                    "   • Two-factor authentication\n" +
                    "   • Social engineering\n\n" +
                    "Just ask me about any of these topics!"
                },
                {
                    new[] { "what can i ask", "what can i ask you about", "topics", "help" },
                    "Great question! Here are topics you can ask me about:\n\n" +
                    "   🔑 Passwords          — e.g., 'how do I create a strong password?'\n" +
                    "   🎣 Phishing            — e.g., 'what is phishing?'\n" +
                    "   🌐 Safe browsing       — e.g., 'how do I browse safely?'\n" +
                    "   🦠 Malware/Viruses     — e.g., 'what is malware?'\n" +
                    "   🔐 2FA                 — e.g., 'what is two-factor authentication?'\n" +
                    "   🕵️ Social engineering  — e.g., 'what is social engineering?'\n" +
                    "   🔒 Encryption          — e.g., 'what is encryption?'\n" +
                    "   📶 Public Wi-Fi        — e.g., 'is public Wi-Fi safe?'"
                },

                // Passwords
                {
                    new[] { "password", "passwords", "strong password", "passphrase" },
                    "🔑 PASSWORD SAFETY TIPS:\n\n" +
                    "   • Use at least 12 characters — longer is stronger.\n" +
                    "   • Mix uppercase, lowercase, numbers, and special characters.\n" +
                    "   • Never use obvious info like your birthday or pet's name.\n" +
                    "   • Use a unique password for EVERY account.\n" +
                    "   • Consider a trusted Password Manager (e.g., Bitwarden, 1Password).\n" +
                    "   • Enable two-factor authentication (2FA) wherever possible.\n\n" +
                    "   ✅ Good example: 'T!ger$unset#2025_Blue'\n" +
                    "   ❌ Bad example:  'password123'"
                },

                // Phishing
                {
                    new[] { "phishing", "phish", "fake email", "scam email", "suspicious email" },
                    "🎣 PHISHING AWARENESS:\n\n" +
                    "   Phishing is when attackers impersonate trusted organisations to steal\n" +
                    "   your credentials or personal data via fake emails, SMS, or websites.\n\n" +
                    "   HOW TO SPOT A PHISHING ATTEMPT:\n" +
                    "   • Urgent language: 'Your account will be closed in 24 hours!'\n" +
                    "   • Suspicious sender address (e.g., support@amaz0n-login.com)\n" +
                    "   • Unexpected attachments or links\n" +
                    "   • Grammar/spelling mistakes in the email\n" +
                    "   • Requests for passwords or payment info\n\n" +
                    "   WHAT TO DO:\n" +
                    "   ✔ Hover over links to check the real URL before clicking.\n" +
                    "   ✔ Report phishing emails to your IT team or email provider.\n" +
                    "   ✔ When in doubt — DELETE it!"
                },

                // Safe browsing
                {
                    new[] { "safe browsing", "browse safely", "safe internet", "secure browsing", "internet safety" },
                    "🌐 SAFE BROWSING HABITS:\n\n" +
                    "   • Always check for 'https://' and a padlock icon in the address bar.\n" +
                    "   • Avoid downloading files from untrusted websites.\n" +
                    "   • Use a reputable browser (Chrome, Firefox, Edge) — keep it updated.\n" +
                    "   • Install an ad-blocker to block malicious ads.\n" +
                    "   • Clear cookies and browsing history regularly.\n" +
                    "   • Avoid entering personal info on sites you do not trust.\n" +
                    "   • Use a VPN when on public networks."
                },

                // Malware / Viruses
                {
                    new[] { "malware", "virus", "ransomware", "trojan", "spyware", "worm" },
                    "🦠 MALWARE & VIRUSES:\n\n" +
                    "   Malware is malicious software designed to damage, disrupt, or gain\n" +
                    "   unauthorised access to computer systems.\n\n" +
                    "   COMMON TYPES:\n" +
                    "   • Virus     — attaches to files and spreads when executed.\n" +
                    "   • Ransomware — encrypts your files and demands payment to unlock them.\n" +
                    "   • Trojan    — disguises itself as legitimate software.\n" +
                    "   • Spyware   — secretly monitors your activity.\n" +
                    "   • Worm      — self-replicates across networks.\n\n" +
                    "   PROTECTION TIPS:\n" +
                    "   ✔ Install and update a reputable antivirus program.\n" +
                    "   ✔ Keep your OS and software up to date.\n" +
                    "   ✔ Do NOT click unknown links or open suspicious attachments.\n" +
                    "   ✔ Regularly back up your important files."
                },

                // 2FA
                {
                    new[] { "two-factor", "2fa", "two factor", "multi-factor", "mfa", "authentication" },
                    "🔐 TWO-FACTOR AUTHENTICATION (2FA):\n\n" +
                    "   2FA adds an extra layer of security beyond just your password.\n" +
                    "   Even if someone steals your password, they still can't log in\n" +
                    "   without your second factor.\n\n" +
                    "   COMMON 2FA METHODS:\n" +
                    "   • SMS code — a one-time code sent to your phone.\n" +
                    "   • Authenticator app — e.g., Google Authenticator, Authy.\n" +
                    "   • Hardware key — e.g., YubiKey (most secure).\n" +
                    "   • Biometrics — fingerprint or face recognition.\n\n" +
                    "   ✅ ALWAYS enable 2FA on your email, banking, and social media accounts!"
                },

                // Social engineering
                {
                    new[] { "social engineering", "pretexting", "baiting", "tailgating", "manipulation" },
                    "🕵️ SOCIAL ENGINEERING:\n\n" +
                    "   Social engineering exploits HUMAN psychology — not software — to\n" +
                    "   trick people into revealing confidential information or taking\n" +
                    "   harmful actions.\n\n" +
                    "   COMMON TACTICS:\n" +
                    "   • Pretexting  — creating a fabricated scenario to extract information.\n" +
                    "   • Baiting     — leaving infected USB drives in public places.\n" +
                    "   • Tailgating  — physically following someone into a secured area.\n" +
                    "   • Vishing     — voice phishing via phone calls.\n\n" +
                    "   HOW TO PROTECT YOURSELF:\n" +
                    "   ✔ Verify identities before sharing any sensitive information.\n" +
                    "   ✔ Be sceptical of unexpected urgent requests.\n" +
                    "   ✔ Follow your organisation's security policies."
                },

                // Encryption
                {
                    new[] { "encryption", "encrypt", "decrypt", "cipher", "ssl", "tls" },
                    "🔒 ENCRYPTION EXPLAINED:\n\n" +
                    "   Encryption converts readable data into an unreadable format using\n" +
                    "   mathematical algorithms. Only someone with the correct key can\n" +
                    "   decrypt and read it.\n\n" +
                    "   WHY IT MATTERS:\n" +
                    "   • Protects your data during transmission (e.g., HTTPS uses TLS).\n" +
                    "   • Keeps sensitive files safe if your device is lost or stolen.\n" +
                    "   • Used in WhatsApp, email, banking apps, and VPNs.\n\n" +
                    "   GOOD PRACTICE:\n" +
                    "   ✔ Ensure websites use HTTPS before submitting data.\n" +
                    "   ✔ Enable full-disk encryption on your laptop (BitLocker / FileVault)."
                },

                // Public Wi-Fi
                {
                    new[] { "public wifi", "public wi-fi", "wifi", "wi-fi", "hotspot" },
                    "📶 PUBLIC WI-FI SAFETY:\n\n" +
                    "   Public Wi-Fi networks (cafes, airports, malls) are often unsecured,\n" +
                    "   making it easy for attackers to intercept your traffic.\n\n" +
                    "   RISKS:\n" +
                    "   • Man-in-the-Middle (MitM) attacks — intercepting your data.\n" +
                    "   • Evil twin hotspots — fake networks impersonating legitimate ones.\n" +
                    "   • Session hijacking — stealing your login cookies.\n\n" +
                    "   SAFETY TIPS:\n" +
                    "   ✔ Use a VPN when connecting to public Wi-Fi.\n" +
                    "   ✔ Avoid accessing banking or sensitive accounts on public networks.\n" +
                    "   ✔ Forget the network when done so you don't auto-reconnect.\n" +
                    "   ✔ Use mobile data instead when possible."
                },
            };
        }

        // ─── Main response logic ──────────────────────────────────────────────────

        public string GetResponse(string input, string userName)
        {
            string lowerInput = input.ToLower().Trim();

            // Check dictionary for keyword matches
            foreach (var entry in _responses)
            {
                foreach (string keyword in entry.Key)
                {
                    if (lowerInput.Contains(keyword))
                    {
                        return entry.Value;
                    }
                }
            }

            // Default fallback
            return $"I didn't quite understand that, {userName}. Could you rephrase?\n\n" +
                   "   Type 'help' to see a list of topics I can assist you with.";
        }
    }

    // ─── Custom comparer so Dictionary can use string[] keys ─────────────────────

    internal class KeyArrayComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[] x, string[] y) => ReferenceEquals(x, y);
        public int GetHashCode(string[] obj) => obj.GetHashCode();
    }
}
