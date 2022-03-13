using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MoodAnalyzer.MoodAnalyzerCustomException;

namespace MoodAnalyzer
{
    public class MoodAnalyser
    {
        public string AnalyzeMood(string moodMessage)
        {
            try
            {
                if (moodMessage == null)
                    throw new MoodAnalyzerCustomException(ExceptionType.NULL_MESSAGE_EXCEPTION, "Null message passed");
                if (moodMessage.Equals(string.Empty))
                    throw new MoodAnalyzerCustomException(ExceptionType.EMPTY_MESSAGE_EXCEPTION, "Empty message passed");
                if (moodMessage.ToLower().Contains("sad"))
                    return "sad";
                else
                    return "happy";
            }
            catch (MoodAnalyzerCustomException ex)
            {
                return ex.Message;
            }
        }
    }
}