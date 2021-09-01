using System;
using System.Diagnostics;

public class Program
{
	public static double CountResult(double x, char oper, double y)
    {
		switch (oper)
		{
			case '+':
				return x + y;
			case '-':
				return x - y;
			case '*':
				return x * y;
			case '/':
                {
					if (y != 0)
						return x / y;
					else
                    {
                        Console.WriteLine("Деление на 0 невозможно, введите другое число.");
						return x;
                    }
                }
			default:
				Console.WriteLine("Был введён недопустимый оператор");
				return x;
		}
    }

	public static void Main()
	{
		System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
	Start:
		Console.WriteLine("Введите запись формата \"x оператор y\"\nДля сброса вычислений введите запятую\nДля завершения работы введите точку\n");

		double x, y, result;
		char oper;
	wrongString:
		string[] a = Console.ReadLine().Split(' ');

		if (a[0] == ".")
		{
			Process.GetCurrentProcess().Kill();
		}
		else if (a[0] == ",")
        {
			Console.Clear();
			goto Start;
        }
		else if(a.Length != 3)
        {
			Console.WriteLine("Вы ввели строку неправильного формата, повторите попытку.");
			goto wrongString;
		}

		x = Convert.ToDouble(a[0]);
		oper = Convert.ToChar(a[1]);
		y = Convert.ToDouble(a[2]);

		result = CountResult(x, oper, y);
        Console.Write(result + " ");

		while(true)
        {
		wrongString2:
			string[] b = Console.ReadLine().Split(' ');
			if (b[0] == ".")
			{
				Process.GetCurrentProcess().Kill();
			}
			else if (b[0] == ",")
            {
				Console.Clear();
				goto Start;
            }
			else if (b.Length != 2)
			{
				Console.WriteLine("Вы ввели строку неправильного формата, повторите попытку.");
				goto wrongString2;
			}
			oper = Convert.ToChar(b[0]);
			y = Convert.ToDouble(b[1]);

			result = CountResult(result, oper, y);
			Console.Write(result + " ");
		}
	}
}