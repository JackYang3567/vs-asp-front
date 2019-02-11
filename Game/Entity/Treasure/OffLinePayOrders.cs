using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Entity.Treasure
{
    [Serializable]
    public class OffLinePayOrders
    {
         public const string Tablename = "OffLinePayOrders";
        public const string _OffLinePayID = "OffLinePayID";
        public const string _Accounts = "Accounts";
        public const string _PayAmount = "PayAmount";
        public const string _ApplyDate = "ApplyDate";
        public const string _OrderID = "OrderID";
        public const string _PaymentType = "PaymentType";
        public const string _BankName = "BankName";

        private int m_offLinePayID;
        private string m_accounts;
        private decimal m_payAmount;
        private DateTime m_applyDate;
        private string m_orderID;
        private int m_paymentType;
        private string m_bankName;

        public int OffLinePayID
        {
            get
            {
                return this.m_offLinePayID;
            }
            set
            {
                this.m_offLinePayID = value;
            }
        }

        public string Accounts
        {
            get
            {
                return this.m_accounts;
            }
            set
            {
                this.m_accounts = value;
            }
        }

        public decimal PayAmount
        {
            get
            {
                return this.m_payAmount;
            }
            set
            {
                this.m_payAmount = value;
            }
        }

        public DateTime ApplyDate
        {
            get
            {
                return this.m_applyDate;
            }
            set
            {
                this.m_applyDate = value;
            }
        }

        public string OrderID
        {
            get
            {
                return this.m_orderID;
            }
            set
            {
                this.m_orderID = value;
            }
        }

        public int PaymentType
        {
            get
            {
                return this.m_paymentType;
            }
            set
            {
                this.m_paymentType = value;
            }
        }

        public string BankName
        {
            get
            {
                return this.m_bankName;
            }
            set
            {
                this.m_bankName = value;
            }
        }

        public OffLinePayOrders()
        {
            this.m_offLinePayID = 0;
            this.m_accounts = "";
            this.m_payAmount = 0m;
            this.m_applyDate = DateTime.Now;
            this.m_orderID = "";
            this.m_paymentType = 0;
            this.m_bankName = "";
        }
    }
}
