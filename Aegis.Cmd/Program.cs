namespace Aegis.Cmd
{
    using PowerArgs;

    [ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
    internal class Program
    {
        [HelpHook]
        public static bool Help { get; set; }

        private static void Main(string[] args)
        {
        }
    }
}
