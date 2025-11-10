using System;

class log

{

    public void Log(string message)

    {

        Console.WriteLine(message);

    }

    public string Log(string message, int level)

    {

        return message + " " + level;

    }

    public string Log(string message, DateTime time)

    {

        return message + " " + time.ToString();

    }

    public string Log(string message, int level, DateTime time)

    {

        return message + " " + level + " " + time.ToString();

    }

}

internal class LogMethods

{

    public static void Main(string[] args)

    {

        log l = new log();

        l.Log("Hello");

        Console.WriteLine("Message and Level:" + l.Log("Hello", 2));

        Console.WriteLine("Message and Time: " + l.Log("Hello", DateTime.Now));

        Console.WriteLine("Message, level and Time: " + l.Log("Hello", 3, DateTime.Now));

        Console.ReadLine();

    }

}


 
 
