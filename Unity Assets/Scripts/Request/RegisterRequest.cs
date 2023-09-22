using CommonPlace;
using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterRequest : Request
{
	private RegisterPanel registerPanel;
	public override void Start()
	{
		base.Start();
		registerPanel = GetComponent<RegisterPanel>();
	}
	public override void OnOperationResponse(OperationResponse operationResponse)
	{
		ReturnCode returnCode = (ReturnCode)operationResponse.ReturnCode;
		if (returnCode == ReturnCode.Success)
		{
			registerPanel.OnRegisterSuccess();
		}
		else
		{
			registerPanel.OnRegisterFailed();
		}
	}

	public override void SendRequest()
	{
		Debug.Log("3");
		Dictionary<byte, object> data = new Dictionary<byte, object>();
		data.Add((byte)ParameterCode.Username, registerPanel.username.text);
		data.Add((byte)ParameterCode.Password, registerPanel.password.text);
		Debug.Log((OperationCode)OpCode);
		PhotonEngine.peer.OpCustom((byte)OpCode, data, true);
	}
}
