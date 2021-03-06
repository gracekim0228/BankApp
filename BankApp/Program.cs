﻿using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************");
            Console.WriteLine("Welcome to my bank!");
            Console.WriteLine("*************");

            while (true)
            {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Print my accounts");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();
                switch (option) {
                    case "0":
                        Console.WriteLine("Thank you for visiting the bank!");
                        return;
                    case "1":
                        try
                        {
                            Console.Write("Email Address: ");
                            var emailAddress = Console.ReadLine();

                            var accountTypes = Enum.GetNames(typeof(AccountType));
                            for (int i = 0; i < accountTypes.Length; i++)
                            {
                                Console.WriteLine($"{i}. {accountTypes[i]}");
                            }

                            Console.Write("Account Type: ");
                            var accountType = Enum.Parse<AccountType>(Console.ReadLine());

                            Console.Write("Account to deposit: ");
                            var amount = Convert.ToDecimal(Console.ReadLine());

                            var a1 = Bank.CreateAccount(emailAddress, accountType, amount);
                            Console.WriteLine($"AN: {a1.AccountNumber}, CD: {a1.CreatedDate}, Balance: {a1.Balance:C}, AT: {a1.AccountType} ");
                        }
                        catch (ArgumentNullException nx)
                        {
                            Console.WriteLine($"Email Address Type Error - {nx.Message} - Please try again!");
                        }
                        catch (ArgumentException ax)
                        {
                            Console.WriteLine($"Account Type Error - {ax.Message} - Please try again!");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Amount error - Please provide a valid amount. Try again!");
                        }                        
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Sorry something went wrong - {ex.Message} - please try again");
                        }

                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        var depositAmount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, depositAmount);
                        Console.WriteLine("Deposit successfully completed!");
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to withdraw: ");
                        var withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNumber, withdrawAmount);
                        Console.WriteLine("Withdrawal successfully completed!");
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                default:
                    break;
                }
            }



        }
        
        private static void PrintAllAccounts()
        {
            var accounts = Bank.GetAllAccountsForUser();
            foreach (var account in accounts)
            {
                Console.WriteLine($"AN: {account.AccountNumber}, CD: {account.CreatedDate}, Balance: {account.Balance:C}, AT: {account.AccountType} ");
            }
        }
    }
}
