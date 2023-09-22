using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonPlace;
using ExitGames.Client.Photon;

public abstract class Request : MonoBehaviour
{
	public OperationCode OpCode;
	public abstract void SendRequest();
	public abstract void OnOperationResponse(OperationResponse operationResponse);
	public virtual void Start()
	{
		PhotonEngine.Instance.requestDict.Add(OpCode, this);
	}
	public void OnDestroy()
	{
		PhotonEngine.Instance.requestDict.Remove(OpCode);
	}
}
