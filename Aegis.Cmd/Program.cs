namespace Aegis.Cmd
{
    using System;
    using Aegis.Cfg;
    using PowerArgs;
    using Newtonsoft.Json;

    [ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
    internal class Program
    {
        [HelpHook]
        public static bool Help { get; set; }

        private static void Main(string[] args)
        {
            var context = new DataContext();
            var repo = new Repository(context);

            var f = repo.GetFeature(1, 0);
            var json = JsonConvert.SerializeObject(f, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}