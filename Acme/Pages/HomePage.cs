using System.Collections.Generic;
using Acme.Models;
using Acme.Selenium;
using OpenQA.Selenium;

namespace Acme
{
    public class HomePage
    {
        public readonly HomePageMap Map;

        public HomePage()
        {
            Map = new HomePageMap();
        }

        public void SortByAmount()
        {
            Map.AmountTableHeader.Click();
        }
    }

    public class HomePageMap
    {
        public IWebElement UsernameLabel => Driver.FindElement(By.Id("logged-user-name-new"));

        public IWebElement CompareExpensesLink => Driver.FindElement(By.Id("showExpensesChart"));

        public IWebElement ShowDataForNextYearButton => Driver.FindElement(By.Id("addDataset"));

        public IWebElement AmountTableHeader => Driver.FindElement(By.Id("amount"));

        public IList<IWebElement> TableRows => Driver.FindElements(By.CssSelector("#transactionsTable tbody tr"));

        public List<Transaction> RecentTransactions
        {
            get
            {
                var transactions = new List<Transaction>();
                foreach (var tableRow in TableRows)
                {
                    var rowCells = tableRow.FindElements(By.TagName("td"));
                    var status = rowCells[0].Text;
                    var date = rowCells[1].Text;
                    var description = rowCells[2].Text;
                    var category = rowCells[3].Text;
                    var strAmount = rowCells[4].Text;

                    if (strAmount.StartsWith("-"))
                    {
                        // "- 320.00 USD" => "-320.00"
                        strAmount = strAmount.Replace(" USD", "").Replace(" ", "");
                    }
                    else
                    {
                        // "+ 17.99 USD" => "17.99"
                        strAmount = strAmount.Split()[1];
                    }

                    transactions.Add(new Transaction
                    {
                        Status = status,
                        Date = date,
                        Description = description,
                        Category = category,
                        Amount = double.Parse(strAmount)
                    });
                }

                return transactions;
            }
        }
    }
}
