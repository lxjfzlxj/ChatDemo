using CommonPlace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public TMP_Text infoTextPrefab;
	public TMP_Text ContentTextPrefab;
	public Transform allContents;
	ScrollRect scrollRect;
	private void Start()
	{
		scrollRect = GetComponent<ScrollRect>();
	}
	public void LoadMessage(OneMessage message)
	{
		TMP_Text infoText = Instantiate(infoTextPrefab);
		infoText.text = message.username + " " + message.time.ToString() + " :";
		infoText.fontSize = 20;
		TMP_Text contentText = Instantiate(ContentTextPrefab);
		contentText.text = message.content;
		contentText.fontSize = 36;
		infoText.transform.SetParent(allContents);
		contentText.transform.SetParent(allContents);
		Canvas.ForceUpdateCanvases();
		scrollRect.verticalNormalizedPosition = 0;
		Canvas.ForceUpdateCanvases();
	}
}
