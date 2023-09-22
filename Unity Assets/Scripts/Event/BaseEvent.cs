using CommonPlace;
using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEvent : MonoBehaviour
{
	public EventCode EvCode;
	public abstract void OnEvent(EventData eventData);
	public virtual void Start()
	{
		PhotonEngine.Instance.eventDict.Add(EvCode,this);
	}
	public virtual void OnDestroy()
	{
		PhotonEngine.Instance.eventDict.Remove(EvCode);
	}
}
