using Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed;
using NUnit.Framework;
using UnityEngine;

namespace Assets.NotTwice.Tools.EditModeTests.Runtime.ScriptableObjects.Variables.Typed
{
	public class StringVariableTests
	{
		[TestCase("imAStringValue", true)]
		[TestCase("imNotAStringValue", false)]
		[TestCase("imARandomStringValue", false)]
		public void EqualMethodTest(string toCompare, bool expectedResult)
		{
			//Arrange
			StringVariable sut = ScriptableObject.CreateInstance<StringVariable>();
			StringVariable variableToCompare = ScriptableObject.CreateInstance<StringVariable>();

			variableToCompare.Value = toCompare;

			sut.Value = "imAStringValue";

			//Act
			var actual = sut.Equals(variableToCompare);

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[Test]
		public void OtherTypeEqualMethodTest()
		{
			//Arrange
			StringVariable sut = ScriptableObject.CreateInstance<StringVariable>();
			int variableToCompare = 32;


			sut.Value = "imAStringValue";

			//Act
			var actual = sut.Equals(variableToCompare);

			//Assert
			Assert.AreEqual(false, actual);
		}

		[TestCase("imAStringValue", true)]
		[TestCase("imNotAStringValue", false)]
		[TestCase("imARandomStringValue", false)]
		public void EqualOperatorTest(string toCompare, bool expectedResult)
		{
			//Arrange
			StringVariable sut = ScriptableObject.CreateInstance<StringVariable>();
			StringVariable variableToCompare = ScriptableObject.CreateInstance<StringVariable>();

			variableToCompare.Value = toCompare;

			sut.Value = "imAStringValue";

			//Act
			var actual = sut == variableToCompare;

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase("imAStringValue", false)]
		[TestCase("imNotAStringValue", true)]
		[TestCase("imARandomStringValue", true)]
		public void NotEqualOperatorTest(string toCompare, bool expectedResult)
		{
			//Arrange
			StringVariable sut = ScriptableObject.CreateInstance<StringVariable>();
			StringVariable variableToCompare = ScriptableObject.CreateInstance<StringVariable>();

			variableToCompare.Value = toCompare;

			sut.Value = "imAStringValue";

			//Act
			var actual = sut != variableToCompare;

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase("imAStringValue")]
		[TestCase("imNotAStringValue")]
		[TestCase("imARandomStringValue")]
		public void GetHashCodeTest(string value)
		{
			//Arrange
			StringVariable sut = ScriptableObject.CreateInstance<StringVariable>();

			sut.Value = value;

			//Act
			var actual = sut.GetHashCode();

			//Assert
			Assert.AreEqual(value.GetHashCode(), actual);
		}
	}
}
