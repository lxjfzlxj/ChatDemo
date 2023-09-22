using CommonPlace;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChatManager : MonoBehaviour
{
	public GameObject scrollView;
	void Start()
	{
		scrollView.GetComponent<InitMessageRequest>().SendRequest();
	}
}
