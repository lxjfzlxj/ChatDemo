using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageJump : MonoBehaviour
{
	public GameObject loginPanel;
	public GameObject registerPanel;
	public void JumpToRegister()
	{
		loginPanel.GetComponent<LoginPanel>().ClearText();
		loginPanel.SetActive(false);
		registerPanel.SetActive(true);
	}
	public void JumpToLogin()
	{
		registerPanel.GetComponent<RegisterPanel>().ClearText();
		loginPanel.SetActive(true);
		registerPanel.SetActive(false);
	}
}
