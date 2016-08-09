using System;

namespace ChainOfResponsibility
{
    internal class ExpenseHandler : IExpenseHandler
    {
        private IExpenseApprover _approver;
        private IExpenseHandler _next;

        public ExpenseHandler(IExpenseApprover expenseApprover)
        {
            this._approver = expenseApprover;
            this._next = EndOfChainHandler.Instance;
        }

        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            ApprovalResponse response = _approver.ApproveExpense(expenseReport);
            if (response == ApprovalResponse.BeyondApprovalLimit)
            {
                return _next.Approve(expenseReport);
            }
            Console.WriteLine($"Approved by {(_approver as Employee).Name}");
            return response;
        }

        public void RegisterNext(IExpenseHandler next)
        {
            this._next = next;
        }
    }
}