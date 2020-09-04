using Crowdfunding.Models;
using Crowdfunding.Models.Dto;
using Crowdfunding.Models.Enums;
using System;
namespace Crowdfunding.Utils
{
    public class BankService
    {
        public static TransactionResult MakeTransaction(BankTransaction bankTransaction)
        {
            string fromAccount = "userAccount";
            string toAccount = bankTransaction.ToAccount;
            TransactionStatus status = TransactionStatus.COMPLETED;
            double amount = bankTransaction.Amount;
            DateTime date = DateTime.Now;

            return new TransactionResult(fromAccount, toAccount, status, amount, date);
        }

        public static TransactionResult MakeReturnTransaction(BankTransaction bankTransaction)
        {
            string fromAccount = "CrowdfundingAccount";
            string toAccount = bankTransaction.ToAccount;
            TransactionStatus status = TransactionStatus.COMPLETED;
            double amount = bankTransaction.Amount;
            DateTime date = DateTime.Now;

            return new TransactionResult(fromAccount, toAccount, status, amount, date);
        }
    }
}