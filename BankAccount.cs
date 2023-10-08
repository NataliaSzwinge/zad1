using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstyBank
{
    class BankAccount
    {
        private List<Transaction> AllTransactions = new List<Transaction>();
        private List<Transaction> Loan = new List<Transaction>();

        private static UInt32 accountNumberSeed = 23232323;
        public UInt32 Number { get; }
        public string Owner { get; set; }
        private decimal balance;

        public decimal Balance
        {
            get {
                decimal transactionSum = 0;
                foreach (var transaction in AllTransactions)
                {
                    transactionSum += transaction.Amount;
                }
                return transactionSum + balance;
            }
            set { balance = value; }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Balance = initialBalance;
            this.Number = accountNumberSeed++;
            Console.WriteLine($"Utworzono nowe kontro z saldem: {initialBalance}");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            Console.WriteLine($"Dokonano wpłaty o kwtocie: {amount}");
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wpłacić kwoty ujemnej");
            }

            Transaction deposit = new Transaction(amount, date, note);
            AllTransactions.Add(deposit);
        }

        public void MakeWithdraw(decimal amount, DateTime date, string note)
        {
            Console.WriteLine($"Dokonano wypłaty o kwtocie: {amount}");
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wpłacić kwoty ujemnej");
            }

            else if (amount > balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Masz za mało pieniędzy");
            }

            balance -= amount;
            Transaction deposit = new Transaction(amount, date, note);
            AllTransactions.Add(deposit);
        }
        public void ListTransactionHistory()
        {
            Console.WriteLine($"Historia transakcji dla konta {Number}:");
            int i = 1;
            foreach (var transaction in AllTransactions)
            {
                Console.WriteLine("=====================");
                Console.WriteLine($"Nr: {i++}");
                Console.WriteLine($"Ammount: {transaction.Amount} Date: {transaction.Date} Note: {transaction.Note}");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Informacje o koncie:");
            Console.WriteLine($"Numer: {Number}");
            Console.WriteLine($"Właściciel: {Owner}");
            Console.WriteLine($"Saldo: {balance}");
        }

        public void MakeLoan(decimal amount, DateTime date, string note)
        {
            int MAX_AMMOUNT = 1000;
            Console.WriteLine($"Porzyczka o kwtocie: {amount}");
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wpłacić kwoty ujemnej");
            }
            if (amount > MAX_AMMOUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Maksymalna kwota kredytu to 1000");
            }

            Transaction loanDeposit = new Transaction(amount, date, note);
            Loan.Add(loanDeposit);
        }

        public void PayLoan(decimal amount, DateTime date, string note)
        {
            int MAX_AMMOUNT = 1000;
            Console.WriteLine($"Spłata porzyczki o kwtocie: {amount}");
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wpłacić kwoty ujemnej");
            }
            if (amount > MAX_AMMOUNT)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Maksymalna kwota kredytu to 1000");
            }

            Transaction loanDeposit = new Transaction(amount, date, note);
            Loan.Add(loanDeposit);
        }
    }
}
