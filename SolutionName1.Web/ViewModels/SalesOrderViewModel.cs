 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolutionName1.Web.ViewModels
{
    public class SalesOrderViewModel
    {
        public string CustomerName { get; set; }
        public string SalesOrderId { get; set; }
        public string PONumber { get; set; }
        public string MessageToClient { get; set; }
    }
}