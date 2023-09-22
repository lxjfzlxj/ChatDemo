using ChatDemo.Handler;
using CommonPlace;
using CommonPlace.Tools;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo
{
	public class ClientPeer : Photon.SocketServer.ClientPeer
	{
		public ClientPeer(InitRequest initRequest) : base(initRequest)
		{
		}

		protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
		{
			ChatDemo.log.Info("reason:"+reasonDetail);
			bool result = ChatDemo.Instance.clientPeers.Remove(this);
			if (!result) ChatDemo.log.Info("cannot find the clientpeer");
		}

		protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
		{
			ChatDemo.log.Info((OperationCode)operationRequest.OperationCode);
			ChatDemo.log.Info(OperationCode.Register);
			ChatDemo.log.Info(OperationCode.Login);
			BaseHandler handler = DictTool.GetValue<OperationCode, BaseHandler>(ChatDemo.Instance.handlerDict, (OperationCode)operationRequest.OperationCode);
			if (handler == null)
			{
				ChatDemo.log.Info("Cannot find the handler!");
			}
			else
			{
				handler.RespondRequest(operationRequest, sendParameters, this);
			}
		}
	}
}
