using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(DependentFieldAttribute))]
public class DependentFieldDrawer : SpecificFieldDrawer {

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return GetDependentFieldValue(property)? EditorGUI.GetPropertyHeight(property, label, true): 0;
	}
	
	protected override void DrawComponent(Rect position, SerializedProperty property, GUIContent label, System.Type p_type)
	{
		DependentFieldAttribute attr = attribute as DependentFieldAttribute;
		if(attr != null)
		{
			bool v_dependentFieldValue = GetDependentFieldValue(property);
			if(v_dependentFieldValue || attr.CheckerFalseDrawOption != CheckerFalseDrawOptionEnum.DontDrawProperty)
			{
				bool v_oldGUIEnabled = GUI.enabled;
				if(!v_dependentFieldValue && attr.CheckerFalseDrawOption == CheckerFalseDrawOptionEnum.ReadOnlyProperty)
					GUI.enabled = false;
				EditorGUI.PropertyField(position, property, label);
				GUI.enabled = v_oldGUIEnabled;
			}
		}
	}

	protected virtual bool GetDependentFieldValue(SerializedProperty property)
	{
		DependentFieldAttribute attr = attribute as DependentFieldAttribute;
		SerializedProperty v_dependentField =  property.serializedObject != null && attr != null? property.serializedObject.FindProperty(attr.DependentBoolFieldName) : null;
		bool v_dependentFieldValue = v_dependentField != null && v_dependentField.propertyType == SerializedPropertyType.Boolean? v_dependentField.boolValue : true;
		if(attr != null && attr.DependenceOption == DependenceOptionEnum.InverseDependence)
			v_dependentFieldValue = !v_dependentFieldValue;
		return v_dependentFieldValue;
	}
}
