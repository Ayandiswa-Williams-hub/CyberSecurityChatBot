

namespace CyberSecurityChatBot
{
    using System.Collections.Generic;

    namespace CyberSecurityChatBot
    {
        public class KeywordResponder
        {
            private readonly Dictionary<string, string> _responses;

            public KeywordResponder()
            {
                _responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "password", "🔑 Use strong, unique passwords with uppercase, lowercase, numbers, and symbols. Consider using a password manager." },
                { "phishing", "⚠️ Phishing is a deceptive attack where cybercriminals impersonate trusted entities to steal sensitive information. Never click suspicious links." },
                { "malware", "🛡️ Malware is malicious software designed to harm your device. Keep your antivirus updated and avoid suspicious downloads." },
                { "2fa", "✅ Two-Factor Authentication (2FA) adds an extra layer of security. Enable it on all important accounts." },
                { "ransomware", "🚨 Ransomware encrypts your files and demands payment. Always maintain regular backups." },
                { "vpn", "🛡️ A VPN encrypts your internet traffic, especially important on public Wi-Fi networks." },
                { "update", "🔄 Keep your software and operating system updated to patch security vulnerabilities." },
                { "privacy", "🔒 Review and adjust your privacy settings on social media and online accounts regularly." },
                { "scam", "❌ Be cautious of unsolicited messages asking for money or personal information." }
            };
            }

            public string GetResponse(string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                    return null;

                string lowerInput = input.ToLower();

                foreach (var keyword in _responses.Keys)
                {
                    if (lowerInput.Contains(keyword))
                    {
                        return _responses[keyword];
                    }
                }

                return null; // No match found
            }
        }
    }
}
