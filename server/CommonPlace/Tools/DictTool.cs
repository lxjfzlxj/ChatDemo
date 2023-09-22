using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPlace.Tools
{
	public class DictTool
	{
		public static T2 GetValue<T1, T2>(Dictionary<T1, T2> dict, T1 key)
		{
			T2 result;
			bool ok = dict.TryGetValue(key, out result);
			if (ok)
			{
				return result;
			}
			else
			{
				return default(T2);
			}
		}
	}
}
