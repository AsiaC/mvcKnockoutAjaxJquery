using SolutionName1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolutionName1.Web.ViewModels
{
    public class SalesOrderViewModel : IObjectWithState
    {
        public string CustomerName { get; set; }
        public int SalesOrderId { get; set; }
        public string PONumber { get; set; }
        public string MessageToClient { get; set; }
        public ObjectState ObjectState { get; set; }
    }
}