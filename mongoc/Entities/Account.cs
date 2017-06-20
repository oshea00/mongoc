using System;

namespace mongoc.Entities
{
    public class Account : Entity
    {
        public string   AccountCode { get; set; }
        public string   AccountName { get; set; }
        public string   AccountTypeCode { get; set; }
        public DateTime AccountOpened { get; set; }
        public double   AccountBalance { get; set; }

        public override string ToString()
        {
            return $"{AccountCode} {AccountName} {AccountTypeCode} {AccountOpened.ToShortDateString()} {AccountBalance}";
        }
    }
}
