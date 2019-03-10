using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    /// <summary>
    /// Account that represents
    /// bank account here you can
    /// withdraw or deposit money
    /// </summary>
    class Account
    {
        #region Properties
        /// <summary>
        /// Unique number for the account
        /// </summary>
        public int AccountNumber { get; set; }
        /// <summary>
        /// Email address of the account holder
        /// </summary>
        public string EmailAddress { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public DateTime CreatedDate { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount">Amount to be deposited</param>
        public void Deposit(decimal amount)
        {
            //Balance = Balance + amount;
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
        #endregion

    }
}
