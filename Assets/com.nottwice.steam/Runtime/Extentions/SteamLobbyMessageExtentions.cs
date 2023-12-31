﻿using Assets.com.nottwice.steam.Runtime.Attributes;
using Assets.com.nottwice.steam.Runtime.Serializables;
using System;
using System.Linq;
using System.Reflection;

namespace Assets.com.nottwice.steam.Runtime.Extentions
{
	/// <summary>
	/// Extension class for easier management of steam chat messages, to be used by the program
	/// </summary>
	public static class SteamLobbyMessageExtentions
	{
		/// <summary>
		/// Method for reading an array of strings and converting it to a generic instance
		/// </summary>
		public static T ConvertFromArgs<T>(this string[] args)
			where T : SteamLobbyMessage, new()
		{
			T instance = new T();

			PropertyInfo[] properties = GetOrderedProperties<T>();

			for (int i = 0; i < Math.Min(properties.Length, args.Length); i++)
			{
				object value = Convert.ChangeType(args[i], properties[i].PropertyType);

				properties[i].SetValue(instance, value);
			}

			return instance;
		}

		/// <summary>
		/// Method for converting a generic instance into a string with information separated by the separator character
		/// </summary>
		public static string ConvertToArgs<T>(this T instance, string separator)
			where T : SteamLobbyMessage, new()
		{
			PropertyInfo[] properties = GetOrderedProperties<T>();

			string[] args = new string[properties.Length];

			for (int i = 0; i < properties.Length; i++)
			{
				object value = properties[i].GetValue(instance);
				args[i] = value?.ToString() ?? string.Empty;
			}

			return string.Join(separator, args.Reverse());
		}

		private static PropertyInfo[] GetOrderedProperties<T>()
		{
			Type orderAttributeType = typeof(OrderAttribute);

			return typeof(T).GetProperties()
				.Where(p => Attribute.IsDefined(p, orderAttributeType))
				.OrderBy(p => ((OrderAttribute)p.GetCustomAttributes(orderAttributeType, false).Single()).Order)
				.Select(p => p).ToArray();
			;
		}
	}
}
