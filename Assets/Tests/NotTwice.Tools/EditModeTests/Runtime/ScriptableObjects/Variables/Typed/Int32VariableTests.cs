using Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed;
using NUnit.Framework;
using UnityEngine;

namespace Assets.NotTwice.Tools.EditModeTests.Runtime.ScriptableObjects.Variables.Typed
{
	public class Int32VariableTests
	{
		[TestCase(32, true)]
		[TestCase(64, false)]
		[TestCase(128, false)]
		public void EqualMethodTest(int toCompare, bool expectedResult)
		{
			//Arrange
			Int32Variable sut = ScriptableObject.CreateInstance<Int32Variable>();
			Int32Variable variableToCompare = ScriptableObject.CreateInstance<Int32Variable>();

			variableToCompare.Value = toCompare;

			sut.Value = 32;

			//Act
			var actual = sut.Equals(variableToCompare);

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[Test]
		public void OtherTypeEqualMethodTest()
		{
			//Arrange
			Int32Variable sut = ScriptableObject.CreateInstance<Int32Variable>();
			string variableToCompare = "imAStringValue";


			sut.Value = 32;

			//Act
			var actual = sut.Equals(variableToCompare);

			//Assert
			Assert.AreEqual(false, actual);
		}

		[TestCase(32, true)]
		[TestCase(64, false)]
		[TestCase(128, false)]
		public void EqualOperatorTest(int toCompare, bool expectedResult)
		{
			//Arrange
			Int32Variable sut = ScriptableObject.CreateInstance<Int32Variable>();
			Int32Variable variableToCompare = ScriptableObject.CreateInstance<Int32Variable>();

			variableToCompare.Value = toCompare;

			sut.Value = 32;

			//Act
			var actual = sut == variableToCompare;

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase(32, false)]
		[TestCase(64, true)]
		[TestCase(128, true)]
		public void NotEqualOperatorTest(int toCompare, bool expectedResult)
		{
			//Arrange
			Int32Variable sut = ScriptableObject.CreateInstance<Int32Variable>();
			Int32Variable variableToCompare = ScriptableObject.CreateInstance<Int32Variable>();

			variableToCompare.Value = toCompare;

			sut.Value = 32;

			//Act
			var actual = sut != variableToCompare;

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase(32)]
		[TestCase(64)]
		[TestCase(128)]
		public void GetHashCodeTest(int value)
		{
			//Arrange
			Int32Variable sut = ScriptableObject.CreateInstance<Int32Variable>();

			sut.Value = value;

			//Act
			var actual = sut.GetHashCode();

			//Assert
			Assert.AreEqual(value.GetHashCode(), actual);
		}
	}
}
