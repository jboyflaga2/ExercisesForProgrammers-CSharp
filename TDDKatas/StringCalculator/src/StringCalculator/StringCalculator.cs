using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
	// This project can output the Class library as a NuGet Package.
	// To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
	public class StringCalculator
	{
		public int Add(string numbers)
		{
			if (string.IsNullOrEmpty(numbers))
				return 0;

			int sum = 0;
			bool isFirstCharANumber = IsFirstCharacterANumber(numbers);
			if(isFirstCharANumber)
			{
				sum = Add(",\n", numbers);
			}
			else
			{
				MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(numbers));
				StreamReader reader = new StreamReader(memStream);
				string delimeters = reader.ReadLine();
				if (delimeters.Contains('-'))
					throw new Exception("The negative sign is not allowed as a delimeter.");
				string rest = reader.ReadToEnd();
				sum = Add(delimeters, rest);
			}

			return sum;
		}

		private int Add(string delimeters, string numbers)
		{
			int sum = 0, intNum;
			var listOfNumbers = numbers.Split(delimeters.ToCharArray());
			foreach (string num in listOfNumbers)
			{
				intNum = int.Parse(num);
				if (intNum < 0)
					throw new Exception("Negatives are not allowed");
				sum += int.Parse(num);
			}

			return sum;
		}

		private bool IsFirstCharacterANumber(string numbers)
		{
			int firstChar;
			bool isFirstCharANegativeSign = numbers[0] == '-';
			string strFirstChar = isFirstCharANegativeSign ? numbers[1].ToString() : numbers[0].ToString();
			bool isChar = int.TryParse(strFirstChar, out firstChar);
			return isChar;
		}
	}
}
