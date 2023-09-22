using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPlace
{
	[Serializable]
	public class OneMessage
	{
		public string username { get; set; }
		public string content { get; set; }
		public DateTime time { get; set; }
	}
}
