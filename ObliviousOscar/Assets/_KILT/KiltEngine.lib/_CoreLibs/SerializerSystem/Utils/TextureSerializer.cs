using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TextureEncoderEnum  { PNG = 0, JPG = 1}

public static class TextureSerializer
{
	#region Save/Load Web

	public static void SerializeToWeb(Texture2D p_textureToSave, string p_url, object p_target = null, string p_callBackFunctionName = "")
	{
		SerializeToWebInternal(p_textureToSave, p_url, null, p_target, p_callBackFunctionName);
	}
	
	public static void SerializeToWeb(Texture2D p_textureToSave, string p_url, Delegates.FunctionPointer<Texture2D, bool> p_callback)
	{
		SerializeToWebInternal(p_textureToSave, p_url, p_callback, null, "");
	}
	
	private static void SerializeToWebInternal(Texture2D p_textureToSave, string p_url, Delegates.FunctionPointer<Texture2D, bool> p_callback, object p_target, string p_callBackFunctionName)
	{
		GameObject v_dummyObject = new GameObject("UploadImageToWWW(Dummy)");
		TextureUploader v_component = v_dummyObject.AddComponent<TextureUploader>();
		v_component.Url = p_url;
		v_component.TextureToUpload = p_textureToSave;
		v_component.FunctionAndParameters.DelegatePointer = p_callback;
		v_component.FunctionAndParameters.Target = p_target;
		v_component.FunctionAndParameters.StringFunctionName = p_callBackFunctionName;
	}

	public static void DeserializeFromWeb(string p_url, object p_target, string p_callBackFunctionName, bool p_isSpriteReturn = false)
	{
		DeserializeFromWebInternal(p_url, null, p_target, p_callBackFunctionName, p_isSpriteReturn);
	}

	public static void DeserializeFromWeb(string p_url, Delegates.FunctionPointer<Texture2D> p_callback)
	{
		DeserializeFromWebInternal(p_url, p_callback, null, "", false);
	}

	public static void DeserializeFromWeb(string p_url, Delegates.FunctionPointer<Sprite> p_callback)
	{
		DeserializeFromWebInternal(p_url, p_callback, null, "", true);
	}

	private static void DeserializeFromWebInternal(string p_url, System.Delegate p_callback, object p_target, string p_callBackFunctionName, bool p_isSpriteReturn)
	{
		if(p_callback != null || p_target != null)
		{
			GameObject v_dummyObject = new GameObject("RequestImageFromWWW(Dummy)");
			TextureDownloader v_component = v_dummyObject.AddComponent<TextureDownloader>();
			v_component.Url = p_url;
			v_component.FunctionAndParameters.DelegatePointer = p_callback;
			v_component.FunctionAndParameters.Target = p_target;
			v_component.FunctionAndParameters.StringFunctionName = p_callBackFunctionName;
			v_component.IsSprite = p_isSpriteReturn;
		}
	}

	#endregion

	#region Save/Load Disk

	public static bool Serialize(Texture2D p_textureToSave, string p_folder, string p_file, bool p_folderIsRelativePath = true)
	{
		string v_resultPath = KiltUtils.GetCompleteDataPath(p_folder, p_file, p_folderIsRelativePath);
		return Serialize(p_textureToSave, v_resultPath);
	}

	public static bool Serialize(Texture2D p_textureToSave, string p_fullPathWithFileName)
	{
		bool v_sucess = false;
		if(p_textureToSave != null)
		{
			try
			{
				string v_fileExtension = KiltUtils.GetFileExtension(p_fullPathWithFileName).ToLower();
				//Data to Save
				byte[] v_data  = v_fileExtension.Contains("jpg") || v_fileExtension.Contains("jpeg")? p_textureToSave.EncodeToJPG() : p_textureToSave.EncodeToPNG();
				SerializeData(v_data, p_fullPathWithFileName);
			}
			catch{}
		}
		return v_sucess;
	}

	public static Texture2D Deserialize(string p_folder, string p_file, bool p_folderIsRelativePath = true)
	{
		string v_resultPath = KiltUtils.GetCompleteDataPath(p_folder, p_file, p_folderIsRelativePath);
		return Deserialize(v_resultPath);
	}

	public static Texture2D Deserialize(string p_fullPathWithFileName)
	{
		Texture2D v_return = null;
		try
		{
			string v_fileNameWithoutExtension = KiltUtils.GetFileName(p_fullPathWithFileName, false);
			string v_resultPath = p_fullPathWithFileName;
			string v_folderPath = v_resultPath.Replace(KiltUtils.GetFileName(p_fullPathWithFileName, true), "");
			string v_resourcesPath = KiltUtils.PathCombine(v_folderPath, v_fileNameWithoutExtension);
			v_resourcesPath = KiltUtils.PathUncombine(v_resourcesPath, KiltUtils.GetCurrentDataPath());
			
			//Try Resources.Load
			if(v_return == null)
			{
				Texture2D v_textureAsset = Resources.Load<Texture2D>(v_resourcesPath) as Texture2D;
				if(v_textureAsset != null)
					v_return = v_textureAsset;
			}
			//Try Traditional Methods
			#if UNITY_WEBPLAYER && !UNITY_EDITOR
			if(v_return == null)
			{
				v_return = DeserializeFromPlayerPrefs(v_resourcesPath);
			}
			#elif UNITY_WEBPLAYER && UNITY_EDITOR
			if(v_return == null && KiltUtils.CallEditorStaticFunctionWithReturn<bool>("SystemIOEditorWebPlayer", "FileExists", v_resultPath))
			{
				byte[] v_bytes = KiltUtils.CallEditorStaticFunctionWithReturn<byte[]>("SystemIOEditorWebPlayer", "ReadAllBytes", v_resultPath);
				v_return = TextureFromBytes(v_bytes);
				
			}
			#elif !UNITY_WEBPLAYER
			if(v_return == null && System.IO.File.Exists(v_resultPath))
			{
				byte[] v_bytes = System.IO.File.ReadAllBytes(v_resultPath);
				v_return = TextureFromBytes(v_bytes);
			}
			#endif
		}
		catch {}
		return v_return;
	}

	#endregion

	#region Save/Load PlayerPrefs

	public static bool SerializeToPlayerPrefs(Texture2D p_textureToSave, string p_key)
	{
		bool v_sucess = false;
		if(p_textureToSave != null)
		{
			try
			{
				string v_fileExtension = KiltUtils.GetFileExtension(p_key).ToLower();
				//Data to Save
				byte[] v_data  = v_fileExtension.Contains("jpg") || v_fileExtension.Contains("jpeg")? p_textureToSave.EncodeToJPG() : p_textureToSave.EncodeToPNG();
				v_sucess = SerializeDataToPlayerPrefs(v_data, p_key);
			}
			catch{}
		}
		return v_sucess;
	}
	
	public static Texture2D DeserializeFromPlayerPrefs(string p_key)
	{
		Texture2D v_return = null;
		try
		{
			if(v_return == null)
			{
				string v_textObject = SerializerHelper.ReadAllTextFromPlayerPrefs(p_key);
				byte[] v_bytes = System.Convert.FromBase64String(v_textObject);
				v_return = TextureFromBytes(v_bytes);
				
			}
		}
		catch {}
		return v_return;
	}

	#endregion
	
	#region Save Data (Internal)

	private static bool SerializeDataToPlayerPrefs(byte[] p_data, string p_key)
	{
		bool v_sucess = false;
		if(p_data != null)
		{
			try
			{
				string v_textToWrite = SerializerHelper.EncodeTo64(p_data, new System.Text.ASCIIEncoding());
				v_sucess = SerializerHelper.WriteAllTextToPlayerPrefs(v_textToWrite, p_key);
			}
			catch{}
		}
		return v_sucess;
	}

	private static bool SerializeData(byte[] p_data, string p_fullPathWithFileName)
	{
		bool v_sucess = false;
		if(p_data != null)
		{
			try
			{
				string v_fileNameWithoutExtension = KiltUtils.GetFileName(p_fullPathWithFileName, false);
				string v_folderPath = p_fullPathWithFileName.Replace(KiltUtils.GetFileName(p_fullPathWithFileName, true), "");
				string v_resourcesPath = KiltUtils.PathCombine(v_folderPath, v_fileNameWithoutExtension);
				v_resourcesPath = KiltUtils.PathUncombine(v_resourcesPath, KiltUtils.GetCurrentDataPath());

				#if UNITY_WEBPLAYER && !UNITY_EDITOR
				v_sucess = SerializeDataToPlayerPrefs(p_data, v_resourcesPath);
				#elif UNITY_WEBPLAYER && UNITY_EDITOR
				KiltUtils.CallEditorStaticFunction("SystemIOEditorWebPlayer", "WriteAllBytes", p_fullPathWithFileName, p_data);
				v_sucess = true;
				#elif !UNITY_WEBPLAYER
				System.IO.File.WriteAllBytes (p_fullPathWithFileName, p_data);
				v_sucess = true;
				#endif
			}
			catch{}
		}
		return v_sucess;
	}

	#endregion

	#region Helper Functions

	public static Texture2D TextureFromBytes(byte[] p_bytes) 
	{
		Texture2D v_tex = null;
		if (p_bytes != null && p_bytes.Length > 0)     
		{
			v_tex = new Texture2D(4, 4); //Prevent Bugs in IOS
			v_tex.LoadImage(p_bytes); //..this will auto-resize the texture dimensions.
		}
		return v_tex;
	}

	#endregion
}
