﻿using Microsoft.Azure.CognitiveServices.Language.SpellCheck;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBookingBot.Chatbot.Extensions
{
    public static class SpellCheckExtensions
    {
        public static async Task<string> SpellCheck(this string text, string apiKey)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            var client = new SpellCheckClient(new ApiKeyServiceClientCredentials(apiKey));
            var spellCheckResult = await client.SpellCheckerAsync(text);

            foreach (var flaggedToken in spellCheckResult.FlaggedTokens)
            {
                text = text.Replace(flaggedToken.Token, flaggedToken.Suggestions.FirstOrDefault().Suggestion);
            }
            return text;
        }
    }
}
