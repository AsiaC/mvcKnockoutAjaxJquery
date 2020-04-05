﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionName1.Model
{
    public class SalesOrder : IObjectWithState
    {
        public string CustomerName { get; set; }
        public int SalesOrderId { get; set; }
        public string PONumber { get; set; }
        public ObjectState ObjectState { get; set; }
    }
}
