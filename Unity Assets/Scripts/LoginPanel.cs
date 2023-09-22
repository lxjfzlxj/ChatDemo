using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginPanel : MonoBehaviour
{
	public TMP_InputField username;
	public TMP_InputField password;
	public TMP_Text hintMessage;
	public void ClearText()
	{
		username.text = "";
		password.text = "";
		hintMessage.text = "";
	}
	public void OnLoginSuccess()
	{
		hintMessage.color = Color.green;
		hintMessage.text = "Login successfully";
		PhotonEngine.myUsername = username.text;
	}
	public void OnLoginFailed()
	{
		hintMessage.color = Color.yellow;
		hintMessage.text = "Please input the right username and password";
	}
}
