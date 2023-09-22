using ChatDemo.Manager;
using CommonPlace;
using CommonPlace.Tools;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Handler
{
	internal class LoginHandler : BaseHandler
	{
		public LoginHandler()
		{
			OpCode = OperationCode.Login;
		}
		public override void RespondRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
		{
			string username = (string)DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Username);
			string password = (string)DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Password);
			UserManager manager = new UserManager();
			bool isok = manager.VerifyUser(username, password);
			OperationResponse response = new OperationResponse(operationRequest.OperationCode);
			if (isok)
			{
				response.ReturnCode = (short)ReturnCode.Success;
				ChatDemo.Instance.clientPeers.Add(peer);
			}
			else
			{
				response.ReturnCode = (short)ReturnCode.Failed;
			}
			peer.SendOperationResponse(response, sendParameters);
		}
	}
}
