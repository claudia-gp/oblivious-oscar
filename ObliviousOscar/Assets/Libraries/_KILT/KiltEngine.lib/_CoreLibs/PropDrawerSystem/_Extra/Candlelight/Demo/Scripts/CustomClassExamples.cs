using UnityEngine;

// Custom classes need to inherit from BackingFieldCompatibleObject or manually implement
// IPropertyBackingFieldCompatible.
[System.Serializable]
public class Character : BackingFieldCompatibleObject
{
	[SerializeField, PropertyBackingField]
	private string m_Name = "";

	public string Name
	{
		get { return m_Name; }
		set
		{
			if (m_Name != value)
			{
				m_Name = string.IsNullOrEmpty(value) ? string.Empty : value;
				Debug.Log(string.Format("set Name: {0}", m_Name));
			}
		}
	}


	[SerializeField, PropertyBackingField]
	private float m_MaxHealth = 0f;

	public float MaxHealth
	{
		get { return m_MaxHealth; }
		set
		{
			if (m_MaxHealth != value)
			{
				m_MaxHealth = Mathf.Clamp01(value);
				Debug.Log(string.Format("set MaxHealth: {0}", m_MaxHealth));
			}
		}
	}

	private Character() {}

	public Character(string name, float maxHealth = 1f)
	{
		Name = name;
		MaxHealth = maxHealth;
	}

	public override object Clone()
	{
		// Call parameterless constructor here, since it does not invoke setters.
		Character clone = new Character();
		clone.m_MaxHealth = this.m_MaxHealth;
		clone.m_Name = this.m_Name;
		return clone;
	}

	public override int GetSerializedPropertiesHash()
	{
		// Only generate a hash code from values that will be serialized.
		return m_MaxHealth.GetHashCode() ^ m_Name.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format("[Character: MaxHealth={0}, Name={1}]", MaxHealth, Name);
	}
}

// Custom structs need to manually implement IPropertyBackingFieldCompatible.
[System.Serializable]
public struct OrdinalName : IPropertyBackingFieldCompatible
{
	[SerializeField]
	private int m_Index;
	
	public int Index { get { return m_Index; } }

	[SerializeField]
	private string m_Name;

	public string Name { get { return m_Name; } }

	public OrdinalName(int index, string name) : this()
	{
		this.m_Index = index;
		this.m_Name = name ?? string.Empty;
	}

	object System.ICloneable.Clone()
	{
		return this;
	}

	public override int GetHashCode()
	{
		return this.m_Index.GetHashCode() ^ this.m_Name.GetHashCode();
	}

	int IPropertyBackingFieldCompatible.GetSerializedPropertiesHash()
	{
		// Only generate a hash code from values that will be serialized.
		// NOTE: All fields on this type are serialized.
		return this.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format("[OrdinalName: Index={0}, Name={1}]", Index, Name);
	}
}