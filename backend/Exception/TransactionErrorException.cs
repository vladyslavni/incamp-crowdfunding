using System;
public class TransactionErrorException : Exception
{
    public TransactionErrorException()
    {}

    public TransactionErrorException(string message)
        : base(message)
    {}

    public TransactionErrorException(string message, Exception inner)
        : base(message, inner)
    {}
}