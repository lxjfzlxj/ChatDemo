using ChatDemo.Handler;
using ChatDemo.Manager;
using ChatDemo.Model;
using CommonPlace;
using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo
{
	public class ChatDemo : ApplicationBase
	{
		public static ChatDemo Instance
		{
			get;
			private set;
		}
		public static readonly ILogger log = LogManager.GetCurrentClassLogger();
		public Dictionary<OperationCode, BaseHandler> handlerDict = new Dictionary<OperationCode, BaseHandler>();
		public List<ClientPeer> clientPeers = new List<ClientPeer>();
		protected override PeerBase CreatePeer(InitRequest initRequest)
		{
			ClientPeer peer = new ClientPeer(initRequest);
			log.Info("[A Client has connected here successfully.]");
			return peer;
		}

		protected override void Setup()
		{
			Instance = this;
			log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "bin_Win64", "log");
			FileInfo configFileInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));
			if (configFileInfo.Exists)
			{
				LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
				XmlConfigurator.ConfigureAndWatch(configFileInfo);
			}
			log.Info("[Setup Completed!]");
			InitHandler();
		}
		public void InitHandler()
		{
			LoginHandler loginHandler = new LoginHandler();
			handlerDict.Add(loginHandler.OpCode, loginHandler);
			RegisterHandler registerHandler = new RegisterHandler();
			handlerDict.Add(registerHandler.OpCode, registerHandler);
			InitMessageHandler initMessageHandler = new InitMessageHandler();
			handlerDict.Add(initMessageHandler.OpCode, initMessageHandler);
			SendMessageHandler sendMessageHandler = new SendMessageHandler();
			handlerDict.Add(sendMessageHandler.OpCode, sendMessageHandler);
		}
		protected override void TearDown()
		{
			log.Info("[The server has torn down.]");
		}
	}
}
