using System;

namespace RepositoryExample.DAO.Utilites
{

	/// <summary>
	/// Helper for working with class propetyes ( copy and etc)
	/// </summary>
	/// <typeparam name="TParent"></typeparam>
	/// <typeparam name="TChild"></typeparam>
	public class ClassPropertyesCopier<TParent, TChild> where TParent : class
		where TChild : class
	{
		/// <summary>
		/// Copy propertyes values from parent class to child, if in child property exists
		/// </summary>
		/// <param name="parent">copy from</param>
		/// <param name="child">copy to</param>
		public static void Copy(TParent parent, TChild child)
		{
			var parentProperties = parent.GetType().GetProperties();
			var childProperties = child.GetType().GetProperties();

			foreach (var parentProperty in parentProperties)
			{
				foreach (var childProperty in childProperties)
				{
					if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
					{
						childProperty.SetValue(child, parentProperty.GetValue(parent));
						break;
					}
				}
			}
		}

	}

	[AttributeUsage(AttributeTargets.Property)]
	public class MatchParentAttribute : Attribute
	{
		public readonly string ParentPropertyName;
		public MatchParentAttribute(string parentPropertyName)
		{
			ParentPropertyName = parentPropertyName;
		}
	}

	public class PropertyMatcherCopier<TParent, TChild> where TParent : class
		where TChild : class
	{
		public static void Copy(TParent parent, TChild child)
		{
			var childProperties = child.GetType().GetProperties();
			foreach (var childProperty in childProperties)
			{
				var attributesForProperty = childProperty.GetCustomAttributes(typeof(MatchParentAttribute), true);
				var isOfTypeMatchParentAttribute = false;

				MatchParentAttribute currentAttribute = null;

				foreach (var attribute in attributesForProperty)
				{
					if (attribute.GetType() == typeof(MatchParentAttribute))
					{
						isOfTypeMatchParentAttribute = true;
						currentAttribute = (MatchParentAttribute)attribute;
						break;
					}
				}

				if (isOfTypeMatchParentAttribute)
				{
					var parentProperties = parent.GetType().GetProperties();
					object parentPropertyValue = null;
					foreach (var parentProperty in parentProperties)
					{
						if (parentProperty.Name == currentAttribute.ParentPropertyName)
						{
							if (parentProperty.PropertyType == childProperty.PropertyType)
							{
								parentPropertyValue = parentProperty.GetValue(parent);
							}
						}
					}

					if (parentPropertyValue != null) // for copy from more than one source
					{
						childProperty.SetValue(child, parentPropertyValue);
					}
				}
			}
		}
	}

}
