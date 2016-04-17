using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculator.Tests
{
	// This project can output the Class library as a NuGet Package.
	// To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
	public class StringCalculator_AddMethod_Tests
	{
		//from: http://www.codeproject.com/Articles/886492/Learning-Test-Driven-Development-with-TDD-Katas

		StringCalculator _calculator;

		public StringCalculator_AddMethod_Tests()
		{
			_calculator = new StringCalculator();
		}

		[Fact]
		public void Given_an_empty_string_should_return_zero()
		{
			int sum = _calculator.Add("");
			Assert.Equal(0, sum);
		}

		[Fact]
		public void Given_a_null_string_should_return_zero()
		{
			int sum = _calculator.Add(null);
			Assert.Equal(0, sum);
		}

		[Fact]
		public void Given_a_single_number_should_return_the_number()
		{
			int sum = _calculator.Add("1");
			Assert.Equal(1, sum);
		}

		[Fact]
		public void Given_two_numbers_should_return_the_sum_of_the_numbers()
		{
			int sum = _calculator.Add("1, 2");
			Assert.Equal(3, sum);
		}

		[Fact]
		public void Given_three_numbers_should_return_the_sum_of_the_numbers()
		{
			int sum = _calculator.Add("1, 2, 3");
			Assert.Equal(6, sum);
		}

		[Fact]
		public void Given_two_numbers_separated_by_newline_return_the_sum_of_the_numbers()
		{
			int sum = _calculator.Add("1\n3");
			Assert.Equal(4, sum);
		}

		[Fact]
		public void Given_three_numbers_separated_by_newline_return_the_sum_of_the_numbers()
		{
			int sum = _calculator.Add("1\n3\n7");
			Assert.Equal(11, sum);
		}

		[Fact]
		public void Use_the_delimeter_given_as_the_first_line_of_the_parameter()
		{
			int sum = _calculator.Add(";\n1;2");
			Assert.Equal(3, sum);
		}

		[Fact]
		public void Use_the_delimeters_given_as_the_first_line_of_the_parameter()
		{
			int sum = _calculator.Add(";:,/\n1;2/3:4,5");
			Assert.Equal(15, sum);
		}

		[Fact]
		public void Throw_exception_if_given_a_negative_number()
		{
			Assert.Throws<Exception>(() => _calculator.Add("-1"));
		}

		[Fact]
		public void Throw_exception_if_given_negative_numbers()
		{
			Assert.Throws<Exception>(() => _calculator.Add("1, -2, 3, -4"));
		}

		[Fact]
		public void Throw_exception_if_the_negative_sign_is_part_of_the_delimeters()
		{
			Assert.Throws<Exception>(() => _calculator.Add("-;,\n1;2,3"));
		}
	}
}
