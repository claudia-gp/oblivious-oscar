using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(MaskEnumAttribute))]
public class MaskEnumDrawer : SpecificFieldDrawer
{	
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		base.OnGUI(position,property,label);
	}

	protected override void DrawComponent(Rect position, SerializedProperty property, GUIContent label, System.Type p_type)
	{
		if(property.propertyType == SerializedPropertyType.Enum && System.Attribute.IsDefined(p_type, typeof(System.FlagsAttribute)))
			property.intValue = EditorGUI.MaskField(position, label, property.intValue, property.enumNames);
		else
			EditorGUI.PropertyField(position, property, label);
	}
}
