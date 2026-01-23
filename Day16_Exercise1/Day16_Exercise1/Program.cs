using static System.Net.Mime.MediaTypeNames;

namespace Day16_Exercise1
{
    class ApplicationConfig
    {
        public static string ApplicationName { get; set; }

        public static string Environment { get; set; }

        public static int AccessCount { get; set; }

        public static bool IsInitialized { get; set; }

        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
            Console.WriteLine("Static Constructor Executed");
        }

        public static void Initialize(string appName, string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            IsInitialized = true;
            AccessCount += 1;
        }

        public static string GetConfigurationSummary()
        {
            AccessCount++;
            return $"Application Name : {ApplicationName}," +
                   $"Environment : {Environment}," +
                   $"Access Count : {AccessCount}," +
                   $"IsInitialized : {IsInitialized}";


        }

        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            IsInitialized = false;
            AccessCount++;
        }
    }

        internal class Program
        {

            static void Main(string[] args)
            {
                ApplicationConfig.ApplicationName = "Clash Royale";
                ApplicationConfig.Initialize("clash", "env");
                Console.WriteLine(ApplicationConfig.GetConfigurationSummary());

                ApplicationConfig.ResetConfiguration();

            Console.WriteLine("Reseted Value");
                Console.WriteLine(ApplicationConfig.GetConfigurationSummary());


            }
        }
    }

    
