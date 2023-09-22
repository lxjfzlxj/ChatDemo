using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegisterPanel : MonoBehaviour
{
	public TMP_InputField username;
	public TMP_InputField password;
	public TMP_Text hintMessage;
	public void ClearText()
	{
		username.text = "";
		password.text = "";
		hintMessage.color = Color.red;
		hintMessage.text = "注意：一定不要使用你平时常用的密码！！一定不要！";
	}
	public void OnRegisterSuccess()
	{
		hintMessage.color = Color.green;
		hintMessage.text = "Register successfully! Please back to login.";
	}
	public void OnRegisterFailed()
	{
		hintMessage.color = Color.yellow;
		hintMessage.text = "The username has been used.";
	}
}
