using UnityEngine;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class RegexUtils
{
	static bool invalid = false;
	public static bool IsValidEmail(string p_strIn)
	{
		invalid = false;
		if (String.IsNullOrEmpty(p_strIn))
			return false;
		
		// Use IdnMapping class to convert Unicode domain names. 
		try {
			p_strIn = Regex.Replace(p_strIn, @"(@)(.+)$", DomainMapper,
			                      RegexOptions.None);
		}
		catch {
			return false;
		}
		
		if (invalid)
			return false;
		
		// Return true if p_strIn is in valid e-mail format. 
		try {
			return Regex.IsMatch(p_strIn,
			                     @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
			                     @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
			                     RegexOptions.IgnoreCase);
		}
		catch {
			return false;
		}
	}
	
	private static string DomainMapper(Match match)
	{
		if(match != null)
		{
			// IdnMapping class with default property values.
			IdnMapping idn = new IdnMapping();
			
			string domainName = match.Groups[2].Value;
			try {
				domainName = idn.GetAscii(domainName);
			}
			catch (ArgumentException) {
				invalid = true;
			}
			return match.Groups[1].Value + domainName;
		}
		invalid = true;
		return "";
	}
}
