using Crowdfunding.Models.Enums;
using System;

namespace Crowdfunding.Models
{
    public class TransactionResult
    {
        public long Id {get; set;}
        public string FromAccount {get; set;}
        public string ToAccount {get; set;}
        public TransactionStatus Status {get; set;}
        public double Amount {get; set;}
        public DateTime Date {get; set;}

        public TransactionResult()
        {
        }

        public TransactionResult(string fromAccount, string toAccount, TransactionStatus status, double amount, DateTime date)
        {
            this.FromAccount = fromAccount;
            this.ToAccount = toAccount;
            this.Status = status;
            this.Amount = amount;
            this.Date = date;
        }
    }
}