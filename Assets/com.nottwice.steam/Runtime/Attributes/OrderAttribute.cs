using System;
using System.Runtime.CompilerServices;

namespace Assets.com.nottwice.steam.Runtime.Attributes
{
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class OrderAttribute : Attribute
	{
		private readonly int order_;

		public OrderAttribute([CallerLineNumber] int order = 0)
		{
			order_ = order;
		}

		public int Order { get { return order_; } }
	}
}
