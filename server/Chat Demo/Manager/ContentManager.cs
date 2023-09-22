using ChatDemo.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Manager
{
	internal class ContentManager
	{
		public void Add(Content content)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					session.Save(content);
					transaction.Commit();
				}
			}
		}
		public ICollection<Content> GetAllContents()
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				IList<Content> contents = session.CreateCriteria(typeof(Content)).List<Content>();
				return contents;
			}
		}
	}
}
