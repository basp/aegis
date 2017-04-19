namespace Aegis.Cmd
{
    using Aegis.Cfg;
    using PowerArgs;

    [ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
    internal class Program
    {
        [HelpHook]
        public static bool Help { get; set; }

        private static void Main(string[] args)
        {
            var context = new DataContext();
            var repo = new Repository(context);
        }
    }
}