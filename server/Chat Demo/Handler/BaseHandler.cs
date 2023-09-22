using CommonPlace;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Handler
{
	public abstract class BaseHandler
	{
		public OperationCode OpCode;
		public abstract void RespondRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer);
	}
}
