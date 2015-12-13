using UnityEngine;
using System.Collections;

public class TextureDownloader : MonoBehaviour
{
	#region Private Variables

	[SerializeField]
	bool m_isSprite = false;
	[SerializeField]
	string m_url = "";
	[SerializeField]
	Texture2D m_textureLoaded = null;
	[SerializeField]
	FunctionAndParameters m_functionAndParameters = new FunctionAndParameters();
	
	bool _requesting = false;
	bool _started = false;
	
	#endregion
	
	#region Public Properties

	public bool IsSprite
	{
		get
		{
			return m_isSprite;
		}
		set
		{
			if(m_isSprite == value)
				return;
			m_isSprite = value;
		}
	}

	public string Url
	{
		get
		{
			return m_url;
		}
		set
		{
			if(m_url == value)
				return;
			m_url = value;
		}
	}
	
	public Texture2D TextureLoaded
	{
		get
		{
			return m_textureLoaded;
		}
		set
		{
			if(m_textureLoaded == value)
				return;
			m_textureLoaded = value;
		}
	}
	
	public FunctionAndParameters FunctionAndParameters
	{
		get
		{
			if(m_functionAndParameters == null)
				m_functionAndParameters = new FunctionAndParameters();
			return m_functionAndParameters;
		}
		set
		{
			if(m_functionAndParameters == value)
				return;
			m_functionAndParameters = value;
		}
	}
	
	#endregion
	
	#region Unity Functions
	
	protected virtual void Awake()
	{
		gameObject.hideFlags = HideFlags.DontSaveInBuild|HideFlags.DontSaveInBuild;
		gameObject.name = "RequestImageFromWWW(Dummy)";
	}
	
	protected virtual void OnEnable()
	{
		if(!string.IsNullOrEmpty(m_url) && _started)
			StartCoroutine(RequestImageFromWWW());
	}
	
	protected virtual void Start()
	{
		_started = true;
		if(Url != null)
			StartCoroutine(RequestImageFromWWW());
		else
			KiltUtils.Destroy(this.gameObject);
	}
	
	protected virtual void OnDisable()
	{
		StopCoroutine(RequestImageFromWWW());
	}
	
	#endregion
	
	#region Helper Functions
	
	IEnumerator RequestImageFromWWW()
	{
		if(Url != null && !_requesting)
		{
			MarkedToDestroy.RemoveMark(this.gameObject);
			TextureLoaded = null;
			_requesting = true;
			// Start a download of the given URL
			WWW v_wwwRequest = new WWW(Url);
			yield return v_wwwRequest;
			//Call callback
			if(v_wwwRequest.error != null)
				Debug.LogWarning("Download Failed: " + v_wwwRequest.error);
			TextureLoaded = v_wwwRequest.error != null? null : v_wwwRequest.texture;
			FunctionAndParameters.Params.Clear();
			if(IsSprite)
			{
				Sprite v_sprite = TextureLoaded != null? Sprite.Create(TextureLoaded, new Rect(0,0,TextureLoaded.width, TextureLoaded.height), new Vector2(0.5f,0.5f)) : null;
				FunctionAndParameters.Params.Add(v_sprite);
			}
			else
				FunctionAndParameters.Params.Add(TextureLoaded);
			FunctionAndParameters.CallFunction();
			_requesting = false;
		}
		KiltUtils.Destroy(this.gameObject);
	}
	
	#endregion
}

