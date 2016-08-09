using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class EndOfChainHandler : IExpenseHandler
    {
        private static EndOfChainHandler _instance;
        private EndOfChainHandler() { }

        public static EndOfChainHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EndOfChainHandler();
                }
                return _instance;
            }
        }

        public ApprovalResponse Approve(IExpenseReport expenseReport) => ApprovalResponse.Denied;

        public void RegisterNext(IExpenseHandler next) {
            throw new InvalidOperationException("End of chain handler must be at the end of the chain!");
        }         
    }
}
