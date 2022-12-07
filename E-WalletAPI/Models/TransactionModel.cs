﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace E_WalletAPI.Models
{
    [Table("Transactions")]
    public class TransactionModel
    {
        [Key]
        public int Id { get; set; }
        public string TransUniqueReference { get; set; }

        public decimal TransactionAmount  { get; set; }
        public TranStatus  TransactionStatus { get; set; }
        public bool IsSuccessful => TransactionStatus.Equals(TranStatus.Success);
        public string TransactionSourceAccount { get; set; }
        public string TransactionDestinationAccount { get; set; }
        public string TransactionParticulars { get; set; }
        public TranType TransactionType{ get; set; }

        public DateTime TransactionDate { get; set; }

        public TransactionModel()
        {
            TransUniqueReference = $"{Guid.NewGuid().ToString().Replace("-","").Substring(1, 27)}";
        }

    }
  

    public enum TranStatus
    {
        Failed,
        Success,
        Error
    }

    public enum TranType
    {
        Deposit,
        Withdrawal,
        Transfer
    }



}
