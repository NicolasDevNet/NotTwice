using Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed;
using NUnit.Framework;
using UnityEngine;

namespace Assets.NotTwice.Tools.EditModeTests.Runtime.ScriptableObjects.Variables.Typed
{
	public class FloatVariableTests
	{
		[TestCase(32.5f, true)]
		[TestCase(98.15f, false)]
		[TestCase(485.652f, false)]
		public void EqualMethodTest(float toCompare, bool expectedResult)
		{
			//Arrange
			FloatVariable sut = ScriptableObject.CreateInstance<FloatVariable>();
			FloatVariable variableToCompare = ScriptableObject.CreateInstance<FloatVariable>();

			variableToCompare.Value = toCompare;

			sut.Value = 32.5f;

			//Act
			var actual = sut.Equals(variableToCompare);

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[Test]
		public void OtherTypeEqualMethodTest()
		{
			//Arrange
			FloatVariable sut = ScriptableObject.CreateInstance<FloatVariable>();
			string variableToCompare = "imAStringValue";


			sut.Value = 32.5f;

			//Act
			var actual = sut.Equals(variableToCompare);

			//Assert
			Assert.AreEqual(false, actual);
		}

		[TestCase(32.5f, true)]
		[TestCase(98.15f, false)]
		[TestCase(485.652f, false)]
		public void EqualOperatorTest(float toCompare, bool expectedResult)
		{
			//Arrange
			FloatVariable sut = ScriptableObject.CreateInstance<FloatVariable>();
			FloatVariable variableToCompare = ScriptableObject.CreateInstance<FloatVariable>();

			variableToCompare.Value = toCompare;

			sut.Value = 32.5f;

			//Act
			var actual = sut == variableToCompare;

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase(32.5f, false)]
		[TestCase(98.15f, true)]
		[TestCase(485.652f, true)]
		public void NotEqualOperatorTest(float toCompare, bool expectedResult)
		{
			//Arrange
			FloatVariable sut = ScriptableObject.CreateInstance<FloatVariable>();
			FloatVariable variableToCompare = ScriptableObject.CreateInstance<FloatVariable>();

			variableToCompare.Value = toCompare;

			sut.Value = 32.5f;

			//Act
			var actual = sut != variableToCompare;

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase(32.5f)]
		[TestCase(98.15f)]
		[TestCase(485.652f)]
		public void GetHashCodeTest(float value)
		{
			//Arrange
			FloatVariable sut = ScriptableObject.CreateInstance<FloatVariable>();

			sut.Value = value;

			//Act
			var actual = sut.GetHashCode();

			//Assert
			Assert.AreEqual(value.GetHashCode(), actual);
		}
	}
}
