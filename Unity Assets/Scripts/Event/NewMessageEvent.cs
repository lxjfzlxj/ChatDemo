using CommonPlace;
using CommonPlace.Tools;
using ExitGames.Client.Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMessageEvent : BaseEvent
{
	UIManager manager;
	public override void Start()
	{
		base.Start();
		manager = GetComponent<UIManager>();
	}
	public override void OnEvent(EventData eventData)
	{
		string objString = (string)DictTool.GetValue<byte, object>(eventData.Parameters, (byte)ParameterCode.Contents);
		OneMessage message = SerializeTool.ToDeserialize<OneMessage>(objString);
		manager.LoadMessage(message);
	}
}
