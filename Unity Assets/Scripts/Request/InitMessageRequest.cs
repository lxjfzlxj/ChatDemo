using CommonPlace;
using CommonPlace.Tools;
using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMessageRequest : Request
{
	UIManager manager;
	public override void Start()
	{
		base.Start();
		manager = GetComponent<UIManager>();
	}
	public override void OnOperationResponse(OperationResponse operationResponse)
	{
		string objString = (string)DictTool.GetValue<byte, object>(operationResponse.Parameters, (byte)ParameterCode.Contents);
		List<OneMessage> list = SerializeTool.ToDeserialize<List<OneMessage>>(objString);
		foreach (OneMessage message in list)
		{
			manager.LoadMessage(message);
		}
	}

	public override void SendRequest()
	{
		Debug.Log("1");
		Dictionary<byte,object> data = new Dictionary<byte, object>();
		PhotonEngine.peer.OpCustom((byte)OpCode, data, true);
	}
}
