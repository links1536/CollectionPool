using System.Collections.Generic;
using Links.CollectionPool.Collections.Generic;
using Links.CollectionPool.Providers.Abstractions;
using Links.CollectionPool.Providers.Core;

namespace Links.CollectionPool.Providers.Generic
{
	public class DictionaryPoolProvider<TKey, TValue>
		: CollectionPoolProvider<DictionaryPool<TKey, TValue>, Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>
		, IDictionaryPoolProvider<TKey, TValue>
		where TKey : notnull
	{
	}
}
