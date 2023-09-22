using ChatDemo.Manager;
using ChatDemo.Model;
using CommonPlace;
using CommonPlace.Tools;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ChatDemo.Handler
{
	internal class InitMessageHandler : BaseHandler
	{
		public InitMessageHandler()
		{
			OpCode = OperationCode.InitMessage;
		}
		public override void RespondRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
		{
			ChatDemo.log.Info("Get the request about initating");
			ContentManager manager = new ContentManager();
			ICollection<Content> contents = manager.GetAllContents();
			Dictionary<byte, object> data = new Dictionary<byte, object>();
			List<OneMessage> list = new List<OneMessage>();
			foreach(Content content in contents)
			{
				list.Add(new OneMessage() { username = content.Username, content = content.Words, time = content.Time });
			}

			//StringWriter sw = new StringWriter();
			//XmlSerializer serializer = new XmlSerializer(typeof(ICollection<Content>));
			//serializer.Serialize(sw, contents);
			//string objString = sw.ToString();
			data.Add((byte)ParameterCode.Contents, SerializeTool.ToSerialize<List<OneMessage>>(list));

			OperationResponse response = new OperationResponse(operationRequest.OperationCode);
			response.Parameters = data;
			peer.SendOperationResponse(response, sendParameters);
		}
	}
}
