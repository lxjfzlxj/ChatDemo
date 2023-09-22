using ChatDemo.Manager;
using CommonPlace.Tools;
using CommonPlace;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatDemo.Model;

namespace ChatDemo.Handler
{
	internal class RegisterHandler : BaseHandler
	{
		public RegisterHandler()
		{
			OpCode = OperationCode.Register;
		}
		public override void RespondRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
		{
			string username = (string)DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Username);
			string password = (string)DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Password);
			UserManager manager = new UserManager();
			User user = manager.GetByUsername(username);
			OperationResponse response= new OperationResponse(operationRequest.OperationCode);
			if (user == null)
			{
				
				user = new User() { Username = username, Password = password };
				manager.Add(user);
				response.ReturnCode = (short)ReturnCode.Success;
			}
			else
			{
				ChatDemo.log.Info(username + " " + password);
				response.ReturnCode = (short)ReturnCode.Failed;
			}
			peer.SendOperationResponse(response, sendParameters);
		}
	}
}
