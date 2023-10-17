using Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed;
using Assets.NotTwice.Tools.Runtime.Serializables.References.Typed;
using NUnit.Framework;
using UnityEngine;

namespace Assets.NotTwice.Tools.EditModeTests.Runtime.Serializables.References.Typed
{
	public class Int32ReferenceTests
	{
		[TestCase(55, true)]
		[TestCase(92, false)]
		[TestCase(198, false)]
		public void EqualMethodTest(int toCompare, bool expectedResult)
		{
			//Arrange
			Int32Reference sut = new Int32Reference();
			Int32Reference variableToCompare = new Int32Reference();

			sut.Variable = ScriptableObject.CreateInstance<Int32Variable>();
			sut.Variable.Value = 55;
			sut.UseConstant = false;

			variableToCompare.Variable = ScriptableObject.CreateInstance<Int32Variable>();
			variableToCompare.Variable.Value = toCompare;
			variableToCompare.UseConstant = false;

			//Act
			var actual = sut.Equals(variableToCompare);

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase(55,true, false)]
		[TestCase(92,true, true)]
		[TestCase(198,false, false)]
		public void EqualWithConstantValueMethodTest(int toCompare, bool useConstant, bool expectedResult)
		{
			//Arrange
			Int32Reference sut = new Int32Reference();
			Int32Reference variableToCompare = new Int32Reference();

			sut.Variable = ScriptableObject.CreateInstance<Int32Variable>();

			sut.Variable.Value = 55;
			sut.ConstantValue = 92;
			sut.UseConstant = useConstant;

			variableToCompare.Variable = ScriptableObject.CreateInstance<Int32Variable>();
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
			Int32Reference sut = new Int32Reference();
			string variableToCompare = "imAStringValue";

			sut.Variable = ScriptableObject.CreateInstance<Int32Variable>();
			sut.UseConstant = false;
			sut.Variable.Value = 55;

			//Act
			var actual = sut.Equals(variableToCompare);

			//Assert
			Assert.AreEqual(false, actual);
		}

		[TestCase(55, true)]
		[TestCase(92, false)]
		[TestCase(198, false)]
		public void EqualOperatorTest(int toCompare, bool expectedResult)
		{
			//Arrange
			Int32Reference sut = new Int32Reference();
			Int32Reference variableToCompare = new Int32Reference();

			sut.Variable = ScriptableObject.CreateInstance<Int32Variable>();
			sut.Variable.Value = 55;
			sut.UseConstant = false;


			variableToCompare.Variable = ScriptableObject.CreateInstance<Int32Variable>();
			variableToCompare.Variable.Value = toCompare;
			variableToCompare.UseConstant = false;

			//Act
			var actual = sut == variableToCompare;

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase(55, false)]
		[TestCase(92, true)]
		[TestCase(198, true)]
		public void NotEqualOperatorTest(int toCompare, bool expectedResult)
		{
			//Arrange
			Int32Reference sut = new Int32Reference();
			Int32Reference variableToCompare = new Int32Reference();

			sut.Variable = ScriptableObject.CreateInstance<Int32Variable>();
			sut.Variable.Value = 55;
			sut.UseConstant = false;

			variableToCompare.Variable = ScriptableObject.CreateInstance<Int32Variable>();
			variableToCompare.Variable.Value = toCompare;
			variableToCompare.UseConstant = false;

			//Act
			var actual = sut != variableToCompare;

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase(55)]
		[TestCase(92)]
		[TestCase(198)]
		public void GetHashCodeTest(int value)
		{
			//Arrange
			Int32Reference sut = new Int32Reference();

			sut.Variable = ScriptableObject.CreateInstance<Int32Variable>();

			sut.Variable.Value = value;
			sut.UseConstant = false;

			//Act
			var actual = sut.GetHashCode();

			//Assert
			Assert.AreEqual(value.GetHashCode(), actual);
		}
	}
}
