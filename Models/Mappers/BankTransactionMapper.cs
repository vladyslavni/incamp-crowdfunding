using Crowdfunding.Models.Dto;

namespace Crowdfunding.Models.Mappers
{
    public class BankTransactionMapper
    {
        public static BankTransaction Map(InvestmentDto investment)
        {
            BankTransaction bankTransaction = new BankTransaction();

            bankTransaction.ToAccount = "123123123123123";
            bankTransaction.Amount = investment.Amount;

            return bankTransaction;
        }

        public static BankTransaction Map(TransactionResult transaction)
        {
            BankTransaction bankTransaction = new BankTransaction();

            bankTransaction.ToAccount = transaction.FromAccount;
            bankTransaction.Amount = transaction.Amount;

            return bankTransaction;   
        }
    }
}