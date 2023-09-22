using ChatDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Manager
{
	internal interface IContentManager
	{
		void Add(Content content);
		//void Update(User user);
		//void Remove(User user);
		//User GetByID(int id);
		//User GetByUsername(string username);
		ICollection<Content> GetAllContents();
		//bool VerifyUser(string username, string password);
	}
}
