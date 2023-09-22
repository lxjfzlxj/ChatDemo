using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Model
{
	public class User
	{
		public virtual int Id { get; set; }
		public virtual string Username { get; set; }
		public virtual string Password { get; set; }
	}
}
