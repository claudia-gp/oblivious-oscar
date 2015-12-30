using UnityEngine;
using System.Collections;

public class MaskEnumAttribute : SpecificFieldAttribute 
{
	#region Constructor
	
	public MaskEnumAttribute() : base(typeof(System.IConvertible))
	{
	}
	
	public MaskEnumAttribute(bool p_readOnly) : base(p_readOnly, typeof(System.IConvertible))
	{
	}
	
	#endregion
}