using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;

public class InspectorUtils 
{
	#region Public Draws

	public static bool DrawButton(string p_text, Color v_color, params GUILayoutOption[] p_layoutOption)
	{
		Color v_oldColor = GUI.backgroundColor;
		GUI.backgroundColor = v_color;
		bool v_sucess = GUILayout.Button(p_text, p_layoutOption);
		GUI.backgroundColor = v_oldColor;
		return v_sucess;
	}

	public static void DrawTitleText(string p_text, Color v_color)
	{
		Color v_oldColor = GUI.backgroundColor;
		GUI.backgroundColor = v_color;
		EditorGUILayout.HelpBox(p_text, MessageType.None);
		GUI.backgroundColor = v_oldColor;
	}

	public static System.IConvertible BitmapPopup(string p_label, System.IConvertible p_enum)
	{
		System.IConvertible p_return = p_enum;
		if(EnumHelper.CheckIfIsEnum(p_enum.GetType() ,true))
		{
			try
			{
				int v_value = (int)((System.IConvertible)p_enum);
				if(string.IsNullOrEmpty(p_label))
					v_value = EditorGUILayout.MaskField(v_value, System.Enum.GetNames(p_enum.GetType()));
				else
					v_value = EditorGUILayout.MaskField(p_label, v_value, System.Enum.GetNames(p_enum.GetType()));
				p_return = ((System.IConvertible)v_value);
			}
			catch{}
		}
		else if(EnumHelper.CheckIfIsEnum(p_enum.GetType() ,false))
		{
			try
			{
				if(string.IsNullOrEmpty(p_label))
					p_return = (System.Enum)EditorGUILayout.EnumPopup((System.Enum)p_enum);
				else
					p_return = (System.Enum)EditorGUILayout.EnumPopup(p_label, (System.Enum)p_enum);
			}
			catch{}
		}

		return p_return;
	}
	
	//Only works with serialized properties
	public static void DrawDefaultList(SerializedObject p_serializedObject , string p_propertyName)
	{
		try
		{
			if(string.IsNullOrEmpty(p_propertyName))
			   p_propertyName = "";
			if(p_serializedObject != null)
			{
				p_serializedObject.Update();

				SerializedProperty v_serializedProperty = p_serializedObject.FindProperty (p_propertyName);
				if(v_serializedProperty != null)
				{
					EditorGUI.BeginChangeCheck();
					EditorGUILayout.PropertyField(v_serializedProperty, true);
					if(EditorGUI.EndChangeCheck())
						p_serializedObject.ApplyModifiedProperties();
				}
				else
					EditorGUILayout.HelpBox("Cannot Find serialized property with name " + p_propertyName , MessageType.Warning);
			}
		}
		catch
		{
			EditorGUILayout.HelpBox("Cannot Find serialized property with name " + p_propertyName , MessageType.Warning);
			EditorGUIUtility.LookLikeControls();
		}
	}

	public static bool DrawArray<ObjectType>(string p_labelString, ref ObjectType[] p_array, bool p_isOpened)
	{
		List<ObjectType> v_list = p_array != null? new List<ObjectType>(p_array) : new List<ObjectType>();
		bool v_return = DrawList<ObjectType>(p_labelString, ref v_list, p_isOpened);
		p_array = v_list.ToArray();
		return v_return;
	}

	public static bool DrawList<ObjectType>(string p_labelString, ref List<ObjectType> p_list, bool p_isOpened)
	{
		IList v_genericList = p_list as IList;
		bool v_return = DrawListInternal<ObjectType>(p_labelString, ref v_genericList, p_isOpened);
		try
		{
			p_list = v_genericList as List<ObjectType>;
		}
		catch{}
		return v_return;
		
	}

	public static bool DrawDictionary<ComparerType, ObjectType>(string p_labelString, ref AOTDictionaryKV<ComparerType, ObjectType> p_dict, bool p_isOpened)
	{
		bool v_return = DrawDictionaryInternal<ComparerType, ObjectType>(p_labelString, ref p_dict, p_isOpened);
		return v_return;
	}

	public static object DrawType<ObjectType>(string p_labelString, object p_object)
	{
		object v_return = default(ObjectType);
		try
		{
			if(typeof(ObjectType) == typeof(float))
			{
				if(string.IsNullOrEmpty(p_labelString))
					v_return = (object)EditorGUILayout.FloatField((float)p_object);
				else
					v_return = (object)EditorGUILayout.FloatField(p_labelString, (float)p_object);
			}
			else if(typeof(ObjectType) == typeof(int))
			{
				if(string.IsNullOrEmpty(p_labelString))
					v_return = (object)EditorGUILayout.IntField((int)p_object);
				else
					v_return = (object)EditorGUILayout.IntField(p_labelString, (int)p_object);
			}
			else if(typeof(ObjectType) == typeof(Color))
			{
				if(string.IsNullOrEmpty(p_labelString))
					v_return = (object)EditorGUILayout.ColorField((Color)p_object);
				else
					v_return = (object)EditorGUILayout.ColorField(p_labelString, (Color)p_object);
			}
			else if(typeof(ObjectType).IsEnum)
			{
				if(string.IsNullOrEmpty(p_labelString))
					v_return = (object)BitmapPopup("",(System.Enum)p_object);
				else
					v_return = (object)BitmapPopup(p_labelString, (System.Enum)p_object);
			}
			else if(typeof(ObjectType) == typeof(string))
			{
				if(string.IsNullOrEmpty(p_labelString))
					v_return = (object)EditorGUILayout.TextField((string)p_object);
				else
					v_return = (object)EditorGUILayout.TextField(p_labelString, (string)p_object);
			}
			else if(typeof(ObjectType) == typeof(Vector4))
			{
				if(string.IsNullOrEmpty(p_labelString))
					v_return = (object)EditorGUILayout.Vector4Field("", (Vector4)p_object);
				else
					v_return = (object)EditorGUILayout.Vector4Field(p_labelString, (Vector4)p_object);
			}
			else if(typeof(ObjectType) == typeof(Vector3))
			{
				if(string.IsNullOrEmpty(p_labelString))
					v_return = (object)EditorGUILayout.Vector3Field("",(Vector3)p_object);
				else
					v_return = (object)EditorGUILayout.Vector3Field(p_labelString, (Vector3)p_object);
			}
			else if(typeof(ObjectType) == typeof(Vector2))
			{
				if(string.IsNullOrEmpty(p_labelString))
					v_return = (object)EditorGUILayout.Vector2Field("",(Vector2)p_object);
				else
					v_return = (object)EditorGUILayout.Vector2Field(p_labelString, (Vector2)p_object);
			}
			else if(typeof(ObjectType) == typeof(Rect))
			{
				if(string.IsNullOrEmpty(p_labelString))
					v_return = (object)EditorGUILayout.RectField("",(Rect)p_object);
				else
					v_return = (object)EditorGUILayout.RectField(p_labelString, (Rect)p_object);
			}
			else if(typeof(ObjectType) == typeof(bool))
			{
				if(string.IsNullOrEmpty(p_labelString))
					v_return = (object)EditorGUILayout.Toggle((bool)p_object);
				else
					v_return = (object)EditorGUILayout.Toggle(p_labelString, (bool)p_object);
			}
			else if(KiltUtils.IsSameOrSubclass(typeof(ObjectType), typeof(AnimationCurve)))
			{
				if(string.IsNullOrEmpty(p_labelString))
					v_return = (object)EditorGUILayout.CurveField((AnimationCurve)p_object);
				else
					v_return = (object)EditorGUILayout.CurveField(p_labelString, (AnimationCurve)p_object);
			}
			else if(KiltUtils.IsSameOrSubclass(typeof(ObjectType), typeof(object)))
			{
				if(string.IsNullOrEmpty(p_labelString))
					v_return = (object)EditorGUILayout.ObjectField((Object)p_object, typeof(ObjectType), true);
				else
					v_return = (object)EditorGUILayout.ObjectField(p_labelString, (Object)p_object, typeof(ObjectType), true);
			}
			else
				EditorGUILayout.HelpBox(typeof(ObjectType) +  " not supported." , MessageType.Warning);
		}
		catch
		{
			EditorGUILayout.HelpBox("Error drawing object.", MessageType.Warning);
		}

		return v_return;
	}

	#endregion

	#region Internal Draws

	private static bool DrawListInternal<ObjectType>(string p_labelString, ref IList p_list, bool p_isOpened)
	{
		p_isOpened = EditorGUILayout.Foldout(p_isOpened, p_labelString);
		try
		{
			//Try Fill Empty Lists
			if(p_list == null)
			{
				try
				{
					p_list = new List<ObjectType>();
				}
				catch{}
			}
			if(p_isOpened)
			{
				if(p_list != null)
				{
					//CheckDummy (This can return Exception, so check before draw anything)
					int v_index = p_list.Add(default(ObjectType));
					p_list.RemoveAt(v_index);

					EditorGUILayout.BeginHorizontal();
					GUILayout.Space(10);
					int v_count = Mathf.Max(0, EditorGUILayout.IntField("Size",p_list.Count));
					EditorGUILayout.EndHorizontal();

					while(v_count != p_list.Count)
					{
						if(v_count > p_list.Count)
							p_list.Add(default(ObjectType));
						else
							p_list.RemoveAt(p_list.Count -1);
					}
					for(int i=0; i<p_list.Count; i++)
					{
						EditorGUILayout.BeginHorizontal();
						GUILayout.Space(10);
						object p_object = DrawType<ObjectType>("Element " + (i+1), p_list[i]);
						p_list[i] = p_object;
						EditorGUILayout.EndHorizontal();
					}
				}
				else
					EditorGUILayout.HelpBox("Array cannot be null" , MessageType.Warning);
			}
		}
		catch
		{
			EditorGUILayout.HelpBox("Array dont accept " + typeof(ObjectType) , MessageType.Warning);
		}
		return p_isOpened;
	}

	private static bool DrawDictionaryInternal<ComparerType, ObjectType>(string p_labelString, ref AOTDictionaryKV<ComparerType, ObjectType> p_dict, bool p_isOpened)
	{
		p_isOpened = EditorGUILayout.Foldout(p_isOpened, p_labelString);
		try
		{
			//Try Fill Empty Lists
			if(p_dict == null)
			{
				try
				{
					p_dict = new AOTDictionaryKV<ComparerType, ObjectType>();
				}
				catch{}
			}
			if(p_isOpened)
			{
				if(p_dict != null)
				{
					EditorGUILayout.BeginHorizontal();
					GUILayout.Space(10);
					int v_count = Mathf.Max(0, EditorGUILayout.IntField("Size",p_dict.Count));
					EditorGUILayout.EndHorizontal();
					
					while(v_count != p_dict.Count)
					{
						if(v_count > p_dict.Count)
							p_dict.Add(new AOTKeyValuePair<ComparerType, ObjectType>());
						else
							p_dict.RemoveAt(p_dict.Count -1);
					}
					for(int i=0; i<p_dict.Count; i++)
					{
						EditorGUILayout.BeginHorizontal();
						GUILayout.Space(10);
						object p_comparer = DrawType<ComparerType>("Element " + (i+1), p_dict[i].Key);
						object p_object = DrawType<ObjectType>("", p_dict[i].Value);
						p_dict[i] = new AOTKeyValuePair<ComparerType, ObjectType>((ComparerType)p_comparer, (ObjectType)p_object);
						EditorGUILayout.EndHorizontal();
					}
				}
				else
					EditorGUILayout.HelpBox("Dictionary cannot be null" , MessageType.Warning);
			}
		}
		catch
		{
			EditorGUILayout.HelpBox("Dictionary dont accept " + typeof(ObjectType) , MessageType.Warning);
		}
		return p_isOpened;
	}

	#endregion
}
