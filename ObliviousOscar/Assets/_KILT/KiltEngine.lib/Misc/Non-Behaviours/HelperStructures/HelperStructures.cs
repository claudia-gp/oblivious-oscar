using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#region ScheduledContainer/Receivers Helper Structs

[System.Serializable]
public abstract class GenericShowObjectStruct
{
	#region Private Variables
	
	[SerializeField]
	GameObject m_objectToApply = null;
	
	#endregion

	#region Public Properties

	public GameObject ObjectToApply 
	{
		get 
		{
			return m_objectToApply;
		} 
		set 
		{ 
			if(m_objectToApply == value)
				return;
			m_objectToApply = value;
		} 
	}

	#endregion
}

[System.Serializable]
public abstract class GenericShowObjectStructWithAction<ActionType> : GenericShowObjectStruct where ActionType: GenericStateAction
{
	#region Private Variables

	[SerializeField]
	List<ActionType> m_stateActionsList = new List<ActionType>();
	
	#endregion
	
	#region Public Properties

	public List<ActionType> StateActionsList 
	{
		get 
		{
			if(m_stateActionsList == null)
				m_stateActionsList = new List<ActionType>();
			return m_stateActionsList;
		} 
		set 
		{
			m_stateActionsList = value;
		} 
	}
	
	#endregion
}

public enum ShowObjectActionEnum {Show, Hide, ShowFinish, HideFinish }

[System.Serializable]
public class GenericStateAction
{
	#region Private Variables

	[SerializeField]
	ShowObjectActionEnum m_action =  ShowObjectActionEnum.Show;
	[SerializeField]
	float m_delayToCallAction = 0;
	
	#endregion
	
	#region Public Properties

	public ShowObjectActionEnum Action {get {return m_action;} set {m_action = value;} }
	public float DelayToCallAction {get {return m_delayToCallAction;} set {m_delayToCallAction = value;} }

	#endregion
}

[System.Serializable]
public class GenericStateActionWithConditions<ConditionType> : GenericStateAction
{
	#region Private Variables
	
	[SerializeField]
	ConditionType m_stateToMakeAction = default(ConditionType);
	
	#endregion
	
	#region Public Properties
	
	public ConditionType StateToMakeAction {get {return m_stateToMakeAction;} set {m_stateToMakeAction = value;} }
	
	#endregion
}

#endregion

#region ShowHideButton Helper Structs

[System.Serializable]
public class ObjectShowActionStruct
{
	#region Private Variables
	
	[SerializeField]
	GameObject m_objectToApply = null;
	[SerializeField]
	float m_delayToCallAction = 0;
	[SerializeField]
	ShowObjectActionEnum m_action = ShowObjectActionEnum.Show;
	
	#endregion
	
	#region Public Properties
	
	public GameObject ObjectToApply {get {return m_objectToApply;} set { m_objectToApply = value;} }
	public float DelayToCallAction {get {return m_delayToCallAction;} set {m_delayToCallAction = value;} }
	public ShowObjectActionEnum Action {get {return m_action;} set {m_action = value;} }
	
	#endregion
}

#endregion