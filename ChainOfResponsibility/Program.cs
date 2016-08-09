using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpenseHandler William = new ExpenseHandler(new Employee("William Worker", Decimal.Zero));
            ExpenseHandler Mary = new ExpenseHandler(new Employee("Mary Manager", new decimal(1000)));
            ExpenseHandler Victor = new ExpenseHandler(new Employee("Victor Vicepres", new decimal(5000)));
            ExpenseHandler Paula = new ExpenseHandler(new Employee("Paula Pres", new decimal(20000)));

            William.RegisterNext(Mary);
            Mary.RegisterNext(Victor);
            Victor.RegisterNext(Paula);

            Decimal expenseReportAmount;
            do
            {
                Console.Write("Expense Report Amout: ");
                Decimal.TryParse(Console.ReadLine(), out expenseReportAmount);
                IExpenseReport expense = new ExpenseReport(expenseReportAmount);
                ApprovalResponse response = William.Approve(expense);
                Console.WriteLine($"The request was {response}");

                Console.WriteLine("Again? ");
            } while (Console.ReadLine() != "");
        }
    }
}
