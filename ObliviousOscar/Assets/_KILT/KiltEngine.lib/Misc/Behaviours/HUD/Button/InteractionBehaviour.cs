using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ButtonTrigger {OnClick, OnMouseOver, OnMouseOut, OnPress, OnRelease, OnDoubleClick, None, OnAwake, OnEnable, OnStart, OnDisable, OnApplicationQuit, OnLevelWasLoaded, OnGainFocus, OnLoseFocus }
public enum PauseActionEnum {Pause, Resume, None, ForceResume}

public class InteractionBehaviour : MonoBehaviour , UnityEngine.EventSystems.IEventSystemHandler{

	#region Private Variables
	
	[SerializeField]
	ButtonTrigger m_trigger = ButtonTrigger.OnClick;
	[SerializeField]
	KeyCode m_keyToLauch = KeyCode.None;
	[SerializeField]
	PauseActionEnum m_pauseAction = PauseActionEnum.None;
	[SerializeField]
	float m_timeBeetweenSends = 0.8f;
	[SerializeField]
	bool m_forceKinematicBeforePressTouch = true;
	[SerializeField]
	bool m_canCallWhenLoadingScene = false;

	bool _started = false;
	bool _highlighted = false;
	
	bool _oldKinematic = true;

	float _currentTimeBeetweenSends = 0;
	#endregion

	#region Protected Properties

	protected bool Started
	{
		get {return _started;} 
		set
		{
			if(_started == value)
				return;
			_started = value;
		}
	}

	protected bool Highlighted
	{
		get {return _highlighted;} 
		set
		{
			if(_highlighted == value)
				return;
			_highlighted = value;
		}
	}

	protected bool OldKinematic
	{
		get {return _oldKinematic;} 
		set
		{
			if(_oldKinematic == value)
				return;
			_oldKinematic = value;
		}
	}

	#endregion

	#region Public Properties

	public PauseActionEnum PauseAction
	{ 
		get {return m_pauseAction;} 
		set {m_pauseAction = value;}
	}

	public KeyCode KeyToLauch
	{
		get {return m_keyToLauch;} 
		set
		{
			if(m_keyToLauch == value)
				return;
			m_keyToLauch = value;
		}
	}

	public ButtonTrigger Trigger 
	{
		get {return m_trigger;} 
		set
		{
			if(m_trigger == value)
				return;
			m_trigger = value;
		}
	}

	public float TimeBeetweenSends 
	{
		get {return m_timeBeetweenSends;} 
		set
		{
			if(m_timeBeetweenSends == value)
				return;
			m_timeBeetweenSends = value;
		}
	}

	public bool ForceKinematicBeforePressTouch 
	{
		get {return m_forceKinematicBeforePressTouch;} 
		set
		{
			if(m_forceKinematicBeforePressTouch == value)
				return;
			m_forceKinematicBeforePressTouch = value;
		}
	}

	public bool CanCallWhenLoadingScene
	{
		get {return m_canCallWhenLoadingScene;} 
		set
		{
			if(m_canCallWhenLoadingScene == value)
				return;
			m_canCallWhenLoadingScene = value;
		}
	}

	#endregion

	#region Unity Functions

	protected virtual void Awake()
	{
		if(Trigger == ButtonTrigger.OnAwake) 
			CallSend();
	}

	protected virtual void Start () 
	{ 
		Started = true;
		if(Trigger == ButtonTrigger.OnStart) 
			CallSend();
	}
	
	protected virtual void OnEnable () 
	{ 
		if (Started && Highlighted) 
			OnHover(KiltUICamera.IsHighlighted(gameObject)); 
		if(Trigger == ButtonTrigger.OnEnable) 
			CallSend();
	}

	protected virtual void OnDisable () 
	{ 
		if(Trigger == ButtonTrigger.OnDisable) 
			CallSend();
	}

	protected virtual void OnDestroy () 
	{ 
		//if(Trigger == ButtonTrigger.OnDestroy) 
		//	CallSend();
	}

	protected virtual void Update()
	{
		UpdateTimeBetweenSends();
		if(KeyToLauch != KeyCode.None && Input.GetKeyDown(KeyToLauch))
			CallSend(false);
	}

	protected virtual void OnApplicationQuit() 
	{
		if(Trigger == ButtonTrigger.OnApplicationQuit) 
			CallSend();
	}

	protected virtual void OnLevelWasLoaded(int p_index) 
	{
		if(Trigger == ButtonTrigger.OnLevelWasLoaded)
			CallSend();
	}

	protected virtual void OnApplicationPause(bool p_paused) 
	{
		if(Trigger == ButtonTrigger.OnGainFocus && !p_paused)
			CallSend();
		else if(Trigger == ButtonTrigger.OnLoseFocus && p_paused)
			CallSend();
	}

	#endregion

	#region Event Receivers

	protected virtual void OnHover (bool isOver)
	{
		if (enabled && !CameraFade.InstanceExists())
		{
			if (((isOver && Trigger == ButtonTrigger.OnMouseOver) ||
			     (!isOver && Trigger == ButtonTrigger.OnMouseOut))) 
				CheckSend();
			Highlighted = isOver;
		}
	}
	
	protected virtual void OnPress (bool isPressed)
	{
		if (enabled && !CameraFade.InstanceExists())
		{
			UpdateOldPos();
			UpdateKinematicOnPress(isPressed);
			if (((isPressed && Trigger == ButtonTrigger.OnPress) ||
			     (!isPressed && Trigger == ButtonTrigger.OnRelease))) 
				CheckSend();

		}
	}
	
	protected virtual void OnClick () 
	{ 
		if (enabled && !CameraFade.InstanceExists())
		{
			if(Trigger == ButtonTrigger.OnClick) 
				CheckSend(); 
		}
	}
	
	protected virtual void OnDoubleClick () 
	{ 
		if (enabled && !CameraFade.InstanceExists())
		{
			if (Trigger == ButtonTrigger.OnDoubleClick) 
				CheckSend(); 
		}
	}

	#endregion

	#region Helper Functions

	protected virtual void UpdateTimeBetweenSends()
	{
		if(_currentTimeBeetweenSends > 0)
		{
			_currentTimeBeetweenSends = Mathf.Max(0f, _currentTimeBeetweenSends - GetDeltaTime()) ;
		}
	}

	protected virtual float GetDeltaTime()
	{
		return Time.unscaledDeltaTime; //IgnoreTimeScale? Time.unscaledDeltaTime : Time.deltaTime;
	}

	public bool IsAnyColliderActive()
	{
		List<Collider2D> v_colliders = new List<Collider2D>(GetComponents<Collider2D>());
		v_colliders.MergeList(new List<Collider2D>(GetComponentsInChildren<Collider2D>()));
		foreach(Collider2D v_collider in v_colliders)
		{
			if(v_collider != null)
			{
				if(v_collider.gameObject.activeSelf && v_collider.gameObject.activeInHierarchy && v_collider.enabled)
					return true;
			}
		}
		return false;
	}

	protected void UpdateKinematicOnPress(bool p_isPressed)
	{
		if(ForceKinematicBeforePressTouch)
		{
			if(p_isPressed)
			{
				UpdateOldKinematic();
				SetKinematic(true);
			}
			else
				SetKinematic(OldKinematic);
		}
	}

	private void SetKinematic(bool p_value)
	{
		Rigidbody2D v_body = GetComponent<Rigidbody2D>();
		if(v_body == null)
			v_body = GetComponentInChildren<Rigidbody2D>();
		if(v_body != null)
			v_body.isKinematic = p_value;
	}

	protected virtual void UpdateOldKinematic()
	{
		Rigidbody2D v_body = GetComponent<Rigidbody2D>();
		if(v_body != null)
			OldKinematic = v_body.isKinematic;
	}

	Vector2 _oldPosition = new Vector2(-1,-1);
	protected void UpdateOldPos()
	{
		if(_oldPosition.x < 0 || _oldPosition.y < 0)
		{
			Camera v_camera = CameraManager.GetCameraThatDrawLayer(this.gameObject.layer);
			if(v_camera != null)
				_oldPosition = v_camera.WorldToScreenPoint(transform.position);
		}
	}

	protected void CheckSend()
	{
		if(CanCallWhenLoadingScene || !SceneManager.IsLoading())
		{
			Camera v_camera = CameraManager.GetCameraThatDrawLayer(this.gameObject.layer);
			if(v_camera != null)
			{
				Vector2 v_newPosition = v_camera.WorldToScreenPoint(transform.position);
				float v_xDistance = v_newPosition.x - _oldPosition.x;
				float v_yDistance = v_newPosition.y - _oldPosition.y;
				int v_maxScreenWidthHeight = Mathf.Max(Screen.width,Screen.height);
				if(Mathf.Abs(v_xDistance) < v_maxScreenWidthHeight * 0.015f && Mathf.Abs(v_yDistance) < v_maxScreenWidthHeight * 0.015f)
					CallSend();
				_oldPosition = new Vector2(-1,-1);
			}
			else
				CallSend();
		}
	}

	protected void CallSend(bool p_ignoreFocus = true)
	{
		if(p_ignoreFocus || FocusContainer.IsUnderFocus(this.gameObject))
		{
			if(CanCallWhenLoadingScene || !SceneManager.IsLoading() && _currentTimeBeetweenSends <= 0)
			{
				_currentTimeBeetweenSends = TimeBeetweenSends;
				CallPauseAction();
				BeforeSend();
				Send();
			}
		}
	}

	private void CallPauseAction()
	{
		if(PauseAction == PauseActionEnum.Pause)
			PauseManager.Pause();
		else if(PauseAction == PauseActionEnum.Resume)
			PauseManager.Resume(false);
		else if(PauseAction == PauseActionEnum.ForceResume)
			PauseManager.Resume(true);
	}

	public virtual void Send ()
	{
	}

	protected virtual void BeforeSend()
	{
	}

	#endregion
}
