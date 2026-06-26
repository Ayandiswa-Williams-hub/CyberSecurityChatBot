using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SentimentDetector
{
    public string AnalyzeSentiment(string input)
    {
        string lower = input.ToLower();

      
        if (lower.Contains("great") || lower.Contains("good") || lower.Contains("excellent") ||
            lower.Contains("thanks") || lower.Contains("awesome") || lower.Contains("love"))
        {
            return "positive";
        
        if (lower.Contains("bad") || lower.Contains("hate") || lower.Contains("angry") ||
            lower.Contains("frustrated") || lower.Contains("stupid") || lower.Contains("useless"))
        {
            return "negative";
        }

   
        return "neutral";
    }

    public string GetSentimentResponse(string sentiment)
    {
        return sentiment switch
        {
            "positive" => "😊 I'm glad you're finding this helpful! Stay safe online.",
            "negative" => "I'm sorry to hear that. How can I better assist you with cybersecurity?",
            _ => null
        };
    }
}