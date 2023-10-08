using System;

namespace ProstyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                playWithAccount();
            }
            catch (Exception e)
            {

                Console.WriteLine($"Coś poszło nie tak: {e.Message}");
                Console.ReadKey();
            }
        }

        static public void playWithAccount()
        {
            BankAccount bank = new BankAccount("Jakub", 1000);
            bank.MakeWithdraw(100,DateTime.Now,"wypłata");
            bank.MakeWithdraw(300, DateTime.Now, "wypłata");
            bank.MakeDeposit(100, DateTime.Now, "wpłata");
            bank.MakeLoan(10, DateTime.Now, "porzyczka");
            bank.DisplayInfo();
            bank.ListTransactionHistory();
            Console.ReadKey();
        }

    }
}
