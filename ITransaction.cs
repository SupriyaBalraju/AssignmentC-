namespace Caselet
{
    interface ITransaction
    {
        int FromAccount { get; set; }
        int ToAccount { get; set; }

        void TransferAmount();
    }

    interface IROI
    {
        string TypeOfAccount { get; set; }

        void GetRateOfInterest();
    }
}