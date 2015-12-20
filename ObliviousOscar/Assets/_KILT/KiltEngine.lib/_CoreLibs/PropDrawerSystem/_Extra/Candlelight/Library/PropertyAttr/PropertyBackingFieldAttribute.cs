// 
// PropertyBackingFieldAttribute.cs
// 
// Copyright (c) 2014, Candlelight Interactive, LLC
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 
// 1. Redistributions of source code must retain the above copyright notice,
// this list of conditions and the following disclaimer.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.
// 
// This file contains a custom PropertyAttribute to indicate that a serialized
// field is a backing field for a getter/setter. In order to use it, the
// property to which the field corresponds must implement both get and set
// methods (any access modifiers okay). These methods can be implemented either
// as a property or as methods (e.g., public int SomeInt { get; set; } or
// public int GetSomeInt() / public void SetSomeInt(int)).

using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/// <summary>
/// A custom attribute for specifying that a field is a backing field for a property.
/// </summary>
public class PropertyBackingFieldAttribute : PropertyAttribute
{
	/// <summary>
	/// A regex pattern to guess a property name from a backing field name.
	/// </summary>
	private static readonly System.Text.RegularExpressions.Regex matchPropertyNameInBackingField =
		new System.Text.RegularExpressions.Regex(@"(?<=m_|_)\w+");
	/// <summary>
	/// The warning format string.
	/// </summary>
	private static readonly string warningFormatString = "CA1819: Properties should not return arrays.\n\n" +
		"Consider implementing methods {0} Get{1}() and void Set{1}({0}) in class {2}.";

	/// <summary>
	/// Gets the getter.
	/// </summary>
	/// <value>The getter.</value>
	public System.Func<object, object> Getter { get; private set; }

	/// <summary>
	/// Gets a value indicating whether this instance is initialized.
	/// </summary>
	/// <value><c>true</c> if this instance is initialized; otherwise, <c>false</c>.</value>
	public bool IsInitialized { get; private set; }

	/// <summary>
	/// Gets the override attribute.
	/// </summary>
	/// <value>The override attribute.</value>
	public PropertyAttribute OverrideAttribute { get; private set; }

	/// <summary>
	/// Gets the name of the property.
	/// </summary>
	/// <value>The name of the property.</value>
	public string PropertyName { get ; private set; }

	/// <summary>
	/// Gets the type of the property.
	/// </summary>
	/// <value>The type of the property.</value>
	public System.Type PropertyType { get; private set; }

	/// <summary>
	/// Gets the setter.
	/// </summary>
	/// <value>The setter.</value>
	public System.Action<object, object> Setter { get; private set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="PropertySetterBackingFieldAttribute"/> class that
	/// uses the default property drawer for the field type. Assumes the backing field name starts with "m_" or "_"
	/// and that the property name otherwise matches. For example, a field m_Character or _Character could refer to
	/// either a property Character { get; set; } or a pair of methods GetCharacter() and SetCharacter().
	/// </summary>
	public PropertyBackingFieldAttribute()
	{

	}

	/// <summary>
	/// Initializes a new instance of the <see cref="PropertySetterBackingFieldAttribute"/> class that
	/// uses the default property drawer for the field type.
	/// </summary>
	/// <param name="propertyName">
	/// Name of the getter/setter property corresponding to the backing field, or name of getter/setter methods. For
	/// example, "Character" could refer to either a property Character { get; set; } or a pair of methods
	/// GetCharacter() and SetCharacter().
	/// </param>
	public PropertyBackingFieldAttribute(string propertyName)
	{
		PropertyName = propertyName;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="PropertyBackingFieldAttribute"/> class that
	/// uses a specifically indicated property drawer to display the field in the inspector. Assumes the backing
	/// field name starts with "m_" or "_" and that the property name otherwise matches. For example, a field
	/// m_Character or _Character could refer to either a property Character { get; set; } or a pair of methods
	/// GetCharacter() and SetCharacter().
	/// </summary>
	/// <param name="propertyAttributeOverride">Type to specify what drawer should be used.</param>
	/// <param name="overrideParams">Parameters for the override drawer type.</param>
	public PropertyBackingFieldAttribute(
		System.Type propertyAttributeOverride, params object[] overrideParams
	)
	{
		OverrideAttribute = PropertyAttributeX.CreateNew(propertyAttributeOverride, overrideParams);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="PropertyBackingFieldAttribute"/> class that
	/// uses a specifically indicated property drawer to display the field in the inspector.
	/// </summary>
	/// <param name="propertyName">
	/// Name of the getter/setter property corresponding to the backing field, or name of getter/setter methods. For
	/// example, "Character" could refer to either a property Character { get; set; } or a pair of methods
	/// GetCharacter() and SetCharacter().
	/// </param>
	/// <param name="propertyAttributeOverride">Type to specify what drawer should be used.</param>
	/// <param name="overrideParams">Parameters for the override drawer type.</param>
	public PropertyBackingFieldAttribute(
		string propertyName, System.Type propertyAttributeOverride, params object[] overrideParams
	) : this(propertyAttributeOverride, overrideParams)
	{
		PropertyName = propertyName;
	}

	/// <summary>
	/// Gets the concrete method representation of the supplied method on the supplied provider.
	/// </summary>
	/// <returns>
	/// A concrete representation of the supplied method if it is defined on a generic type; otherwise, the method
	/// itself.
	/// </returns>
	/// <param name="method">Method.</param>
	/// <param name="provider">Provider.</param>
	private MethodInfo GetConcreteMethod(MethodInfo method, object provider)
	{
		if (method.DeclaringType.IsGenericType)
		{
			// just use base type because generic MonoBehaviours and ScriptableObjects only serialize when they are
			// concrete subclasses
			method = provider.GetType().BaseType.GetMethod(method.Name, ObjectX.instanceBindingFlags);
		}
		return method;
	}

	/// <summary>
	/// Initializes this instance of the <see cref="PropertySetterBackingFieldAttribute"/> class that
	/// uses the default property drawer for the field type.
	/// </summary>
	/// <param name="providerType">Type of the provider for the property.</param>
	/// <param name="propertyName">
	/// Name of the getter/setter property corresponding to the backing field, or name of getter/setter methods. For
	/// example, "Character" could refer to either a property Character Character { get; set; } or two methods
	/// Character GetCharacter() / SetCharacters(Character[] characters).
	/// </param>
	public void Initialize(FieldInfo backingField)
	{
		if (IsInitialized)
		{
			return;
		}
		System.Type providerType = backingField.DeclaringType;
		string propertyName = PropertyName; 
		if(string.IsNullOrEmpty(PropertyName))
		{
			propertyName = matchPropertyNameInBackingField.Match(backingField.Name).Value;
			propertyName = !string.IsNullOrEmpty(propertyName)? (propertyName.Length == 1? (char.ToUpper(propertyName[0]) + "") :  (char.ToUpper(propertyName[0]) + propertyName.Substring(1))): propertyName;
			PropertyName = propertyName;
		}
		MethodInfo getter = null;
		MethodInfo setter = null;
		string getterName = propertyName;
		string setterName = propertyName;
		PropertyInfo property = providerType.GetProperty(propertyName, ObjectX.instanceBindingFlags);
		if (property != null)
		{
			getter = property.GetGetMethod(true);
			setter = property.GetSetMethod(true);
			PropertyType = property.PropertyType;
			if (typeof(System.Collections.IList).IsAssignableFrom(PropertyType))
			{
				Debug.LogWarning(string.Format(warningFormatString, PropertyType, propertyName, providerType));
			}
		}
		else
		{
			getterName = string.Format("Get{0}", propertyName);
			setterName = string.Format("Set{0}", propertyName);
			getter = providerType.GetMethod(getterName, ObjectX.instanceBindingFlags);
			// prefer set method with parameter type matching return type of get method
			if (getter != null)
			{
				System.Type[] setterArgs = new System.Type[] { getter.ReturnType };
				setter = providerType.GetMethod(setterName, ObjectX.instanceBindingFlags, null, setterArgs, null);
				PropertyType = getter.ReturnType;
			}
			else
			{
				setter = providerType.GetMethod(setterName, ObjectX.instanceBindingFlags);
			}
		}
		if (getter != null)
		{
			Getter = (provider) => GetConcreteMethod(getter, provider).Invoke(provider, null);
		}
		if (setter != null)
		{
			Setter = delegate(object provider, object value)
			{
				MethodInfo concreteSetter = GetConcreteMethod(setter, provider);
				System.Type concreteParameterType = concreteSetter.GetParameters().First().ParameterType;
				object[] v_params = new object[]{ value == null || !concreteParameterType.IsAssignableFrom(value.GetType()) ? null : value};
				concreteSetter.Invoke(provider,v_params);
			};
		}
		IsInitialized = true;
	}

	#region Obsolete
	[System.Obsolete(
		"Specifying provider type is no longer necessary. " +
		"Use PropertyBackingField() or PropertyBackingField(string)."
	)]
	public PropertyBackingFieldAttribute(System.Type providerType, string propertyName)
	{
		PropertyName = propertyName;
	}

	[System.Obsolete(
		"Specifying provider type is no longer necessary. " +
		"Use PropertyBackingField(System.Type, params object[]) or " +
		"PropertyBackingField(string, System.Type, params object[])."
	)]
	public PropertyBackingFieldAttribute(
		System.Type providerType, string propertyName,
		System.Type propertyAttributeOverride, params object[] overrideParams
	) : this(propertyName)
	{
		OverrideAttribute = PropertyAttributeX.CreateNew(propertyAttributeOverride, overrideParams);
	}
	#endregion
}