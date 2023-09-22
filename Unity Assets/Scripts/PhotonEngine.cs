using CommonPlace;
using CommonPlace.Tools;
using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PhotonEngine : MonoBehaviour,IPhotonPeerListener
{
	public static PhotonPeer Peer
	{
		get
		{
			return peer;
		}
	}
	public static PhotonEngine Instance;
	public static PhotonPeer peer;
	public static string myUsername;
	public Dictionary<OperationCode, Request> requestDict = new Dictionary<OperationCode, Request>();
	public Dictionary<EventCode, BaseEvent> eventDict = new Dictionary<EventCode, BaseEvent>();
	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
	private void Start()
	{
		peer = new PhotonPeer(this, ConnectionProtocol.Udp);
		peer.Connect("127.0.0.1:5055", "ChatApp");
	}
	private void Update()
	{
		peer.Service();
	}
	private void OnDestroy()
	{
		if (peer != null && peer.PeerState == PeerStateValue.Connected)
		{
			peer.Disconnect();
		}
	}
	public void DebugReturn(DebugLevel level, string message)
	{
		Debug.Log(level.ToString() + " " + message);
	}

	public void OnOperationResponse(OperationResponse operationResponse)
	{
		Request request = DictTool.GetValue<OperationCode, Request>(requestDict, (OperationCode)operationResponse.OperationCode);
		Debug.Log("onoperationresponse:" + (OperationCode)operationResponse.OperationCode);
		if(request == null)
		{
			Debug.Log("Can't find the request response handler!");
		}
		else
		{
			request.OnOperationResponse(operationResponse);
		}
	}

	public void OnStatusChanged(StatusCode statusCode)
	{
		Debug.Log(statusCode);
	}

	public void OnEvent(EventData eventData)
	{
		BaseEvent baseEvent = DictTool.GetValue<EventCode, BaseEvent>(eventDict, (EventCode)eventData.Code);
		if(baseEvent == null)
		{
			Debug.Log("Can't find the event handler!");
		}
		else
		{
			baseEvent.OnEvent(eventData);
		}
	}
}
