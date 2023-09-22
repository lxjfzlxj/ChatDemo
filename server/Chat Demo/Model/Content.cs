using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Model
{
	public class Content
	{
		public virtual int Id { get; set; }
		public virtual string Username { get; set; }
		public virtual string Words { get; set; }
		public virtual DateTime Time { get; set; }
	}
}
