using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FocusContainer : MonoBehaviour 
{
	#region Static Properties

	static List<FocusContainer> _focusOrder = new List<FocusContainer>();
	protected static List<FocusContainer> FocusOrder
	{
		get 
		{
			if(_focusOrder == null)
				_focusOrder = new List<FocusContainer>();
			return _focusOrder;
		}
		set
		{
			if(_focusOrder == value)
				return;
			_focusOrder = value;
		}
	}

	#endregion

	#region Unity Functions
	
	protected virtual void OnEnable () 
	{
		RegisterEvents();
		CheckFocus(KiltUtils.GetContainerVisibilityInHierarchy(this.gameObject));
	}

	protected virtual void OnDisable () 
	{
		UnregisterEvents();
		RemoveFocus(this);
	}

	#endregion

	#region Events Receivers

	protected virtual void OnPanelStateChanged(PanelStateEnum p_panelState)
	{
		if(p_panelState == PanelStateEnum.Opening || p_panelState == PanelStateEnum.Opened)
		{
			CheckFocus(p_panelState);
		}
		else
		{
			List<object> v_parameters = new List<object>();
			v_parameters.Add(p_panelState);
			GlobalScheduler.CallFunction(this.gameObject, new Delegates.FunctionPointer<PanelStateEnum>(CheckFocus), v_parameters, 0.1f, true);
		}
	}

	protected virtual void HandleOnGlobalPress (bool p_pressed)
	{
		if(KiltUICamera.currentTouch != null && p_pressed)
		{
			FocusContainer v_directParentFocus = GetDirectFocusContainerComponent(KiltUICamera.currentTouch.pressed);
			if(v_directParentFocus == this)
				FocusContainer.SetFocus(this);
		}
	}

	#endregion

	#region Helper Functions

	protected virtual void CheckFocus(PanelStateEnum p_panelState)
	{
		if(p_panelState == PanelStateEnum.Opening || p_panelState == PanelStateEnum.Opened)
		{
			FocusContainer.SetFocus(this);
		}
		else if(p_panelState == PanelStateEnum.Closing || p_panelState == PanelStateEnum.Closed)
		{
			FocusContainer.RemoveFocus(this);
		}
	}

	protected virtual void RegisterEvents()
	{
		UnregisterEvents();
		GlobalPressController.OnGlobalPress += HandleOnGlobalPress;
	}

	protected virtual void UnregisterEvents()
	{
		GlobalPressController.OnGlobalPress -= HandleOnGlobalPress;
	}

	#endregion

	#region Static Functions

	//If Any Parent or Self contain Focus, Or Focus equal null and panel is Opened or GameObject is Active
	public static bool IsUnderFocus(GameObject p_object)
	{
		if(p_object != null)
		{
			FocusContainer v_focus = FocusContainer.GetFocus();
			PanelStateEnum v_panelState = v_focus == null? PanelStateEnum.Opened : KiltUtils.GetContainerVisibility(v_focus.gameObject);
			if(v_panelState == PanelStateEnum.Opened && (FocusContainer.GetDirectFocusContainerComponent(p_object) == v_focus))
				return true;
		}
		return false;
	}

	public static FocusContainer GetDirectFocusContainerComponent(GameObject p_child)
	{
		if(p_child != null)
		{
			FocusContainer[] v_parentsFocus = p_child.GetComponentsInParent<FocusContainer>();
			FocusContainer v_directParentFocus = null;
			foreach(FocusContainer v_parentFocus in v_parentsFocus)
			{
				if(v_parentFocus != null && v_parentFocus.enabled)
				{
					v_directParentFocus = v_parentFocus;
					break;
				}
			}
			return v_directParentFocus;
		}
		return null;
	}

	public static bool ParentContainFocus(GameObject p_child)
	{
		if(p_child != null)
		{
			FocusContainer v_directParentFocus = GetDirectFocusContainerComponent(p_child);
			return ContainFocus(v_directParentFocus);
		}
		return false;
	}

	public static bool ContainFocus(FocusContainer p_container)
	{
		if(p_container != null && p_container == GetFocus())
		{
			return true;
		}
		return false;
	}

	public static void RemoveFocus(FocusContainer p_container)
	{
		if(p_container != null)
		{
			FocusOrder.RemoveChecking(p_container);
		}
	}

	public static void SetFocus(FocusContainer p_container)
	{
		if(p_container != null && GetFocus() != p_container)
		{
			FocusOrder.RemoveChecking(p_container);
			if(FocusOrder.Count > 0)
				FocusOrder.Insert(0, p_container);
			else
				FocusOrder.Add(p_container);
		}
	}

	public static FocusContainer GetFocus()
	{
		FocusOrder.RemoveNulls();
		FocusContainer v_container = FocusOrder.GetFirst();
		return v_container;
	}

	#endregion
}
