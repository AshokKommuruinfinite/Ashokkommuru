using System;

class OnlineStore

{

    public int CheckOut(int Price)

    {

        return Price;

    }

    public string CheckOut(int Price, int quantity)

    {

        return quantity + " " + Price * quantity;

    }

    public String CheckOut(String CouponCode)

    {

        return CouponCode;

    }

    public String CheckOut(String CouponCode, int quantity, int price)

    {

        return CouponCode + " " + (quantity * price);

    }

}

internal class OnlineStoreCheckOut

{

    public static void Main(string[] args)

    {

        OnlineStore Os = new OnlineStore();

        Console.WriteLine("Price: " + Os.CheckOut(100));

        Console.WriteLine("Price and Quantity: " + Os.CheckOut(100, 3));

        Console.WriteLine("CouponCode: " + Os.CheckOut("abcdf"));

        Console.WriteLine("Total Price and CouponCode: " + Os.CheckOut("abcdf", 5, 500));

        Console.ReadLine();

    }

}



