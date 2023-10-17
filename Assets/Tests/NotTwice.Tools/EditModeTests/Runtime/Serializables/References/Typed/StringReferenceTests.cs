using Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed;
using Assets.NotTwice.Tools.Runtime.Serializables.References.Typed;
using NUnit.Framework;
using UnityEngine;

namespace Assets.NotTwice.Tools.EditModeTests.Runtime.Serializables.References.Typed
{
	public class StringReferenceTests
	{
		[TestCase("imAStringToCompare", true)]
		[TestCase("imNotAStringToCompare", false)]
		[TestCase("imARandomStringToCompare", false)]
		public void EqualMethodTest(string toCompare, bool expectedResult)
		{
			//Arrange
			StringReference sut = new StringReference();
			StringReference variableToCompare = new StringReference();

			sut.Variable = ScriptableObject.CreateInstance<StringVariable>();
			sut.Variable.Value = "imAStringToCompare";
			sut.UseConstant = false;

			variableToCompare.Variable = ScriptableObject.CreateInstance<StringVariable>();
			variableToCompare.Variable.Value = toCompare;
			variableToCompare.UseConstant = false;

			//Act
			var actual = sut.Equals(variableToCompare);

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase("imAStringToCompare",true, false)]
		[TestCase("imNotAStringToCompare",true, true)]
		[TestCase("imARandomStringToCompare",false, false)]
		public void EqualWithConstantValueMethodTest(string toCompare, bool useConstant, bool expectedResult)
		{
			//Arrange
			StringReference sut = new StringReference();
			StringReference variableToCompare = new StringReference();

			sut.Variable = ScriptableObject.CreateInstance<StringVariable>();

			sut.Variable.Value = "imAStringToCompare";
			sut.ConstantValue = "imNotAStringToCompare";
			sut.UseConstant = useConstant;

			variableToCompare.Variable = ScriptableObject.CreateInstance<StringVariable>();
			variableToCompare.Variable.Value = toCompare;
			variableToCompare.UseConstant = false;

			//Act
			var actual = sut.Equals(variableToCompare);

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[Test]
		public void OtherTypeEqualMethodTest()
		{
			//Arrange
			StringReference sut = new StringReference();
			int variableToCompare = 32;

			sut.Variable = ScriptableObject.CreateInstance<StringVariable>();
			sut.UseConstant = false;
			sut.Variable.Value = "imAStringToCompare";

			//Act
			var actual = sut.Equals(variableToCompare);

			//Assert
			Assert.AreEqual(false, actual);
		}

		[TestCase("imAStringToCompare", true)]
		[TestCase("imNotAStringToCompare", false)]
		[TestCase("imARandomStringToCompare", false)]
		public void EqualOperatorTest(string toCompare, bool expectedResult)
		{
			//Arrange
			StringReference sut = new StringReference();
			StringReference variableToCompare = new StringReference();

			sut.Variable = ScriptableObject.CreateInstance<StringVariable>();
			sut.Variable.Value = "imAStringToCompare";
			sut.UseConstant = false;


			variableToCompare.Variable = ScriptableObject.CreateInstance<StringVariable>();
			variableToCompare.Variable.Value = toCompare;
			variableToCompare.UseConstant = false;

			//Act
			var actual = sut == variableToCompare;

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase("imAStringToCompare", false)]
		[TestCase("imNotAStringToCompare", true)]
		[TestCase("imARandomStringToCompare", true)]
		public void NotEqualOperatorTest(string toCompare, bool expectedResult)
		{
			//Arrange
			StringReference sut = new StringReference();
			StringReference variableToCompare = new StringReference();

			sut.Variable = ScriptableObject.CreateInstance<StringVariable>();
			sut.Variable.Value = "imAStringToCompare";
			sut.UseConstant = false;

			variableToCompare.Variable = ScriptableObject.CreateInstance<StringVariable>();
			variableToCompare.Variable.Value = toCompare;
			variableToCompare.UseConstant = false;

			//Act
			var actual = sut != variableToCompare;

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase("imAStringToCompare")]
		[TestCase("imNotAStringToCompare")]
		[TestCase("imARandomStringToCompare")]
		public void GetHashCodeTest(string value)
		{
			//Arrange
			StringReference sut = new StringReference();

			sut.Variable = ScriptableObject.CreateInstance<StringVariable>();

			sut.Variable.Value = value;
			sut.UseConstant = false;

			//Act
			var actual = sut.GetHashCode();

			//Assert
			Assert.AreEqual(value.GetHashCode(), actual);
		}
	}
}
