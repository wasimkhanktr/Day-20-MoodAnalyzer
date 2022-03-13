using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class MoodAnalyzerFactory
    {
        public static object CreateMoodAnalyser(string classname, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(classname, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodanalysis = executing.GetType(classname);
                    return Activator.CreateInstance(moodanalysis);
                }
                catch (ArgumentNullException)
                {
                    return new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CLASS, "No such Class");
                }
            }
            else
            {
                return new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "No Such Method");
            }
        }
    }
}