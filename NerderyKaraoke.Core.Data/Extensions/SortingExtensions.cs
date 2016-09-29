using System.Collections.Generic;
using System.Linq;

using NerderyKaraoke.Core.Data.Models;

namespace NerderyKaraoke.Core.Data.Extensions
{
	public static class SortingExtensions
	{
		public static IEnumerable<SongRequest> FairOrder(this IEnumerable<SongRequest> items)
		{
			var singerGroups = items.GroupBy(i => i.SingerName).ToDictionary(i => i.Key, v => v.OrderBy(i => i.CreateDateTime).ToList());
			var output = new List<SongRequest>();

			while (singerGroups.Any(i => i.Value.Any()))
			{
				var list = singerGroups.Keys.Select(key => singerGroups[key].FirstOrDefault()).Where(item => item != null).ToList();
				output.AddRange(list.OrderBy(i => i.CreateDateTime));

				foreach (var key in singerGroups.Keys.ToArray())
				{
					singerGroups[key] = singerGroups[key].Skip(1).ToList();
				}
			}

			var idx = 1;
			foreach (var item in output)
			{
				item.RequestOrder = idx;
				idx++;
			}

			return output;
		}
	}
}