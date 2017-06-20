﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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