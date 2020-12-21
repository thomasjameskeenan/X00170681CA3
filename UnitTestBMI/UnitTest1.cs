using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMICalculator;
using System.Diagnostics.CodeAnalysis;

namespace BMIUnitTest
{
	[TestClass]
	public class UnitTest1
	{
		[ExcludeFromCodeCoverage]
		[TestMethod]
		public void BMICategory_IntNormalRange_BMIIsNormalReturn()
		{
			BMI bmi = new BMI() { WeightStones = 12, WeightPounds = 0, HeightFeet = 5, HeightInches = 10 };
			Assert.AreEqual(bmi.BMICategory, BMICategory.Normal);
		}
		[TestMethod]
		public void BMICategory_IntUnderweightRange_BMIIsUnderweightReturn()
		{
			BMI bmi = new BMI() { WeightStones = 7, WeightPounds = 0, HeightFeet = 6, HeightInches = 2 };
			Assert.AreEqual(bmi.BMICategory, BMICategory.Underweight);
		}
		[TestMethod]
		public void BMICategory_IntOverweightRange_BMIIsOverweightReturn()
		{
			BMI bmi = new BMI() { WeightStones = 14, WeightPounds = 0, HeightFeet = 6, HeightInches = 2 };
			Assert.AreEqual(bmi.BMICategory, BMICategory.Overweight);
		}
		[TestMethod]
		public void BMICategory_IntObeseRange_ObeseReturn()
		{
			BMI bmi = new BMI() { WeightStones = 45, WeightPounds = 0, HeightFeet = 6, HeightInches = 2 };
			Assert.AreEqual(bmi.BMICategory, BMICategory.Obese);
		}
	}
}
