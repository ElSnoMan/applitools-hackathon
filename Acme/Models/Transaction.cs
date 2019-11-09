namespace Acme.Models
{
    public class Transaction
    {
        public string Status { get; set; }

        public string Date { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public double Amount { get; set; }

        public override bool Equals(object obj)
        {
            var transaction = obj as Transaction;

            return (transaction != null)
                && (Status == transaction.Status)
                && (Date == transaction.Date)
                && (Description == transaction.Description)
                && (Category == transaction.Category)
                && (Amount == transaction.Amount);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
