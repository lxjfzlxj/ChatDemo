using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using CommonPlace;
using CommonPlace.Tools;
using UnityEngine.SceneManagement;

public class LoginRequest : Request
{
	private LoginPanel loginPanel;
	public override void Start()
	{
		base.Start();
		loginPanel = GetComponent<LoginPanel>();
	}
	public override void OnOperationResponse(OperationResponse operationResponse)
	{
		ReturnCode returnCode = (ReturnCode)operationResponse.ReturnCode;
		if (returnCode == ReturnCode.Success)
		{
			loginPanel.OnLoginSuccess();
			SceneManager.LoadScene("ChatScene");
		}
		else
		{
			loginPanel.OnLoginFailed();
		}
	}

	public override void SendRequest()
	{
		Debug.Log("2");
		Dictionary<byte, object> data = new Dictionary<byte, object>();
		data.Add((byte)ParameterCode.Username, loginPanel.username.text);
		data.Add((byte)ParameterCode.Password, loginPanel.password.text);
		Debug.Log((OperationCode)OpCode);
		PhotonEngine.peer.OpCustom((byte)OpCode, data, true);
	}
}
