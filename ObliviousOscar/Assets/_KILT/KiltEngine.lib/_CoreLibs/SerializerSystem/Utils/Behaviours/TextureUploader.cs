using UnityEngine;
using System.Collections;

public class TextureUploader : MonoBehaviour
{
	#region Private Variables
	
	[SerializeField]
	string m_url = "";
	[SerializeField]
	Texture2D m_textureToUpload = null;
	[SerializeField]
	FunctionAndParameters m_functionAndParameters = new FunctionAndParameters();
	
	bool _uploading = false;
	bool _started = false;
	
	#endregion
	
	#region Public Properties
	
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
	
	public Texture2D TextureToUpload
	{
		get
		{
			return m_textureToUpload;
		}
		set
		{
			if(m_textureToUpload == value)
				return;
			m_textureToUpload = value;
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
		gameObject.name = "UploadImageToWWW(Dummy)";
	}
	
	protected virtual void OnEnable()
	{
		if(!string.IsNullOrEmpty(m_url) && _started)
			StartCoroutine(UploadImageToWWW());
	}
	
	protected virtual void Start()
	{
		_started = true;
		if(Url != null)
			StartCoroutine(UploadImageToWWW());
		else
			KiltUtils.Destroy(this.gameObject);
	}
	
	protected virtual void OnDisable()
	{
		StopCoroutine(UploadImageToWWW());
	}
	
	#endregion
	
	#region Helper Functions
	
	IEnumerator UploadImageToWWW()
	{
		if(Url != null && TextureToUpload != null && !_uploading)
		{
			_uploading = true;
			string v_fileExtension = KiltUtils.GetFileExtension(Url).ToLower();
			string v_fileNameWithExtension = KiltUtils.GetFileName(Url, true);
			//Data to Save
			byte[] v_data  = v_fileExtension.Contains("jpg") || v_fileExtension.Contains("jpeg")? TextureToUpload.EncodeToJPG() : TextureToUpload.EncodeToPNG();
			// Create a Web Form
			WWWForm v_form = new WWWForm ();
			v_form.AddField ("action", "Upload Image" );
			v_form.AddBinaryData ("fileUpload", v_data, v_fileNameWithExtension, "image/png" );
			
			// Upload to a cgi script 
			WWW v_www = new WWW(Url, v_form);
			yield return v_www;
			if(v_www.error != null)
				Debug.Log("Upload Failed: " + v_www.error);
			FunctionAndParameters.Params.Clear();
			FunctionAndParameters.Params.Add(TextureToUpload);
			FunctionAndParameters.Params.Add(v_www.error != null? false : true);
			FunctionAndParameters.CallFunction();
			_uploading = false;
		}
		KiltUtils.Destroy(this.gameObject);
	}
	
	#endregion
}

/*
 //Simple PHP Scrip (Server)
 <?php
	 if ( isset ($_POST['action']) ) 
	 {
	 	if($_POST['action'] == "Upload Image") 
	 	{
	 		unset($imagename);

	 		if(!isset($_FILES) isset($HTTP_POST_FILES)) 
	 			$_FILES = $HTTP_POST_FILES;

	 		if(!isset($_FILES['fileUpload']))
	 			$error["image_file"] = "An image was not found.";

	 		$imagename = basename($_FILES['fileUpload']['name']);

	 		if(empty($imagename)) 
	 			$error["imagename"] = "The name of the image was not found.";

	 		if(empty($error)) 
	 		{
	 			$newimage = "images/" . $imagename;
	 			//echo $newimage;
	 			$result = @move_uploaded_file($_FILES['fileUpload']['tmp_name'], $newimage);
	 			if ( empty($result) ) 
	 				$error["result"] = "There was an error moving the uploaded file.";
	 		}
	 	}
	 } 
	 else 
	 {
	 	echo "no form data found";
	 }
 ?>
*/
