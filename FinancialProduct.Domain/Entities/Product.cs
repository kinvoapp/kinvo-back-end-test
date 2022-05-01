
namespace FinancialProduct.Domain.Entities;
public class Product : Base
{
    public Product(string title, int value, string user)
    {
        Title = title;
        Value = value;
        Drawee = false;
        CreatedDate = DateTime.UtcNow.Date;
        User = user;
    }

    public string Title { get; private set; }

    public int Value { get; private set; }

    public string User { get; private set; }

    public bool Drawee { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public DateTime WithdrawalDate { get; private set; }

    public void MarkAsWithdrawn()
    {   
        Value = 0;
        Drawee = true;
        WithdrawalDate = DateTime.UtcNow.Date.AddMonths(6);
        
    }

    public string CalculateTribute()
    {
        var count = 0;


        if (CreatedDate.CompareTo(WithdrawalDate) < 0)
        {
            count = WithdrawalDate.Month - CreatedDate.Month;
            if (count < 12)
            {
                return "0.225";
            }
            else if (count > 12 && count < 24)
            {
                return "0.185";
            }
            else if (count > 24)
            {
                return "0.15";
            }
        }
        return "0";
    }
    public void Apply(int value)
    {
        Value += value;
    }

}