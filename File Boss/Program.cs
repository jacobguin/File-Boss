namespace File_Boss
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (args.Count() != 0)
            {
                Application.Run(new Form1() {cd = args[0], cd_ = true});
            }
            else
            {
                Application.Run(new Form1());
            }
        }
    }
}