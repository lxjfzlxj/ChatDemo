using CommonPlace;
using CommonPlace.Tools;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Handler
{
	internal class SendMessageHandler : BaseHandler
	{
		public SendMessageHandler()
		{
			OpCode = OperationCode.SendMessage;
		}
		public override void RespondRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
		{
			Dictionary<byte, object> data = operationRequest.Parameters;
			string objString = (string)DictTool.GetValue<byte, object>(data, (byte)ParameterCode.Contents);
			OneMessage message = SerializeTool.ToDeserialize<OneMessage>(objString);
			OperationResponse response = new OperationResponse(operationRequest.OperationCode);
			response.ReturnCode = (short)ReturnCode.Success;
			peer.SendOperationResponse(response, sendParameters);

			foreach(ClientPeer clientPeer in ChatDemo.Instance.clientPeers)
			{
				EventData eventData = new EventData((byte)EventCode.NewMessage);
				eventData.Parameters = data;
				clientPeer.SendEvent(eventData, sendParameters);
			}
		}
	}
}
