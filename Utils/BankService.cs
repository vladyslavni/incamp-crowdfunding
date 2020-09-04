using Crowdfunding.Models;
using Crowdfunding.Models.Dto;
using Crowdfunding.Models.Enums;
using System;
namespace Crowdfunding.Utils
{
    public class BankService
    {
        public static TransactionStatus MakeTransaction(double amount)
        {
            return TransactionStatus.COMPLETED;
        }

        public static TransactionStatus MakeReturnTransaction(double amount)
        {
            return TransactionStatus.COMPLETED;
        }
    }
}