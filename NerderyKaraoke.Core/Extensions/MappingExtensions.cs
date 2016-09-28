using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Omu.ValueInjecter;
using Omu.ValueInjecter.Utils;

namespace NerderyKaraoke.Core.Extensions
{
	public static class MappingExtensions
	{
		public static T InjectFrom<T>(this T target, params object[] source)
		{
			if (source == null || source.Any(x => x == null))
				throw new ArgumentNullException(nameof(source), "Cannot inject from null sources.");

			var result = source.Aggregate(target, (current, item) => (T) StaticValueInjecter.InjectFrom(current, item));

			return result;
		}

		public static T InjectFromDynamic<T>(this T target, dynamic source)
		{
			var hydratedSource = source as IDictionary<string, object>;

			if (hydratedSource == null)
				return target;

			var targetProperties = target.GetProps();

			foreach (var item in hydratedSource)
			{
				var targetProperty = targetProperties
														.FirstOrDefault(p => string.Equals(p.Name, item.Key, StringComparison.OrdinalIgnoreCase));
				targetProperty?.SetValue(target, item.Value);
			}

			return target;
		}
	}
}
