using UnityEngine;
using System.Collections;

public class ParameterNameReceiver : GenericReceiver<ShowObjectByParameterNameStruct> 
{
	#region Events
	
	protected virtual void HandleOnParameterAdded(string p_name, object p_value)
	{
		CallActions(p_name, p_value);
	}
	
	#endregion
	
	#region Helper Functions
	
	protected virtual void CallActions(string p_name, object p_value)
	{
		foreach(ShowObjectByParameterNameStruct v_struct in ObjectsToEnableOrDisable)
		{
			if(v_struct != null && v_struct.ObjectToApply != null)
			{
				if(v_struct.StateActionsList != null)
				{
					foreach (ParameterNameStateAction v_stateAction in v_struct.StateActionsList)
					{
						if(v_stateAction != null)
						{
							if(v_stateAction.StateToMakeAction.Equals(p_name))
							{
								KiltUtils.SetContainerVisibility(v_struct.ObjectToApply, v_stateAction.Action, v_stateAction.DelayToCallAction, true);
								break;
							}
						}
					}
				}
			}
		}
	}
	
	protected override void RegisterEvents()
	{
		UnregisterEvents();
		SceneManager.OnParameterAdded += HandleOnParameterAdded;
	}
	
	protected override void UnregisterEvents()
	{
		SceneManager.OnParameterAdded -= HandleOnParameterAdded;
	}
	
	#endregion
}
	
	#region Helper Classes
	
	[System.Serializable]
	public class ShowObjectByParameterNameStruct : GenericShowObjectStructWithAction<ParameterNameStateAction>
	{
	}
	
	[System.Serializable]
	public class ParameterNameStateAction : GenericStateActionWithConditions<string>
	{
	}
	
	#endregion

