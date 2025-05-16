using Blackjack_Dealer_Perspective.classes;

namespace Blackjack_Dealer_Perspective
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            HouseRules rules = HouseRules.GetInstance();

            Console.WriteLine(6 % 4);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}