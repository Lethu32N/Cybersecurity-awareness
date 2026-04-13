using System;

namespace CybersecurityBot.Validation
{
    public class InputValidator
    {
        // ─── Name Validation ──────────────────────────────────────────────────────

        /// <summary>
        /// Validates that a name is not null, empty, or whitespace only.
        /// </summary>
        public bool IsValidName(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // ─── General Input Validation ─────────────────────────────────────────────

        /// <summary>
        /// Validates general chat input — rejects null, empty, or whitespace-only entries.
        /// </summary>
        public bool IsValidInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            // Reject if input is only special characters / numbers (no alphabetic content)
            bool hasLetter = false;
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    hasLetter = true;
                    break;
                }
            }

            return hasLetter;
        }
    }
}
