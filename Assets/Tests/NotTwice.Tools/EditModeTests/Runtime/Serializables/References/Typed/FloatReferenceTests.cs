using Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed;
using Assets.NotTwice.Tools.Runtime.Serializables.References.Typed;
using NUnit.Framework;
using UnityEngine;

namespace Assets.NotTwice.Tools.EditModeTests.Runtime.Serializables.References.Typed
{
	public class FloatReferenceTests
	{
		[TestCase(32.5f, true)]
		[TestCase(98.15f, false)]
		[TestCase(485.652f, false)]
		public void EqualMethodTest(float toCompare, bool expectedResult)
		{
			//Arrange
			FloatReference sut = new FloatReference();
			FloatReference variableToCompare = new FloatReference();

			sut.Variable = ScriptableObject.CreateInstance<FloatVariable>();
			sut.Variable.Value = 32.5f;
			sut.UseConstant = false;

			variableToCompare.Variable = ScriptableObject.CreateInstance<FloatVariable>();
			variableToCompare.Variable.Value = toCompare;
			variableToCompare.UseConstant = false;

			//Act
			var actual = sut.Equals(variableToCompare);

			//Assert
			Assert.AreEqual(expectedResult, actual);
		}

		[TestCase(32.5f,true, false)]
		[TestCase(98.15f,true, true)]
		[TestCase(485.652f,false, false)]
		public void EqualWithConstantValueMethodTest(float toCompare, bool useConstant, bool expectedResult)
		{
			//Arrange
			FloatReference sut = new FloatReference();
			FloatReference variableToCompare = new FloatReference();

			sut.Variable = ScriptableObject.CreateInstance<FloatVariable>();

			sut.Variable.Value = 32.5f;
			sut.ConstantValue = 98.15f;
			sut.UseConstant = useConstant;

			variableToCompare.Variable = ScriptableObject.CreateInstance<FloatVariable>();
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
			FloatReference sut = new FloatReference();
			string variableToCompare = "imAStringValue";

			sut.Variable = ScriptableObject.CreateInstance<FloatVariable>();
			sut.UseConstant = false;
			sut.Variable.Value = 32.5f;

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
			FloatReference sut = new FloatReference();
			FloatReference variableToCompare = new FloatReference();

			sut.Variable = ScriptableObject.CreateInstance<FloatVariable>();
			sut.Variable.Value = 32.5f;
			sut.UseConstant = false;


			variableToCompare.Variable = ScriptableObject.CreateInstance<FloatVariable>();
			variableToCompare.Variable.Value = toCompare;
			variableToCompare.UseConstant = false;

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
			FloatReference sut = new FloatReference();
			FloatReference variableToCompare = new FloatReference();

			sut.Variable = ScriptableObject.CreateInstance<FloatVariable>();
			sut.Variable.Value = 32.5f;
			sut.UseConstant = false;

			variableToCompare.Variable = ScriptableObject.CreateInstance<FloatVariable>();
			variableToCompare.Variable.Value = toCompare;
			variableToCompare.UseConstant = false;

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
			FloatReference sut = new FloatReference();

			sut.Variable = ScriptableObject.CreateInstance<FloatVariable>();

			sut.Variable.Value = value;
			sut.UseConstant = false;

			//Act
			var actual = sut.GetHashCode();

			//Assert
			Assert.AreEqual(value.GetHashCode(), actual);
		}
	}
}
