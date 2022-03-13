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
        public static object CreateMoodAnalyserUsingParameterizedConstructer(string classname, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(classname) || type.FullName.Equals(classname))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo cons = type.GetConstructor(new Type[] { typeof(string) });
                    object instance = cons.Invoke(new object[] { message });
                    return instance;
                }
                else
                    return new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor Not Found");
            }
            else
            {
                return new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CLASS, "No Such Class");
            }
        }
    }
}