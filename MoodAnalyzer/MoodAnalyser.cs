using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class MoodAnalyser
    {
        public string AnalyzeMood(string moodMessage)
        {
            if (moodMessage.ToLower().Contains("sad"))
                return "sad";
            else
                return "happy";
        }
    }
}