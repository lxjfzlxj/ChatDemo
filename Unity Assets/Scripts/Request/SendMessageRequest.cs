using CommonPlace;
using CommonPlace.Tools;
using ExitGames.Client.Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SendMessageRequest : Request
{
	public TMP_InputField inputField;
	public override void OnOperationResponse(OperationResponse operationResponse)
	{
		if (operationResponse.ReturnCode == (short)ReturnCode.Success)
		{
			Debug.Log("Succeed to send message");
		}
	}

	public override void SendRequest()
	{
		Debug.Log("4");
		OneMessage message = new OneMessage()
		{
			username = PhotonEngine.myUsername,
			content = inputField.text,
			time = DateTime.Now
		};
		string objString = SerializeTool.ToSerialize<OneMessage>(message);
		Dictionary<byte, object> data = new Dictionary<byte, object>();
		data.Add((byte)ParameterCode.Contents, objString);
		PhotonEngine.peer.OpCustom((byte)OpCode, data, true);
		inputField.text = "";
	}
}
