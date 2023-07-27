using System;
namespace UserInterface{
    public static class UI{

        public static void WelcomeUI(){
           Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine(@"
######       ##      ##      #  #      #  #  ##      #  #########
#     #     #  #     # #     #  #    #    #  # #     #      #  
#     #    #    #    #  #    #  #  #      #  #  #    #      #
######    ########   #   #   #  # #          #   #   #      #
#     #  #        #  #    #  #  #  #         #    #  #      #
#     #  #        #  #     # #  #    #       #     # #      #
######   #        #  #      ##  #      #     #      ##      #
");
           Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Hello, and welcome to BANKN'T, the bank that doesn't solve your problems!");
            Console.WriteLine("First, you need to sign in, or register in case you're new here");
            Console.WriteLine("Press any key.");
            Console.WriteLine("---------------------------------------------------------------------------");
        }
        public static void LoginUI(){
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Press either 1 to sign in, or 2 to register yourself into our \"Database\"... ");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Cancel Operation");
            Console.WriteLine("---------------------------------------------------------------------------");
        }
        public static void MainMenuUI(){
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("OPTIONS");
            Console.WriteLine("\n1.Current Balance");
            Console.WriteLine("2.Withdrawal");
            Console.WriteLine("3.Deposit");
            Console.WriteLine("4.Transfer");
            Console.WriteLine("5.Transactions");
            Console.WriteLine("6.Logout");
            Console.WriteLine("---------------------------------------------------------------------------");
        }
    }
}
