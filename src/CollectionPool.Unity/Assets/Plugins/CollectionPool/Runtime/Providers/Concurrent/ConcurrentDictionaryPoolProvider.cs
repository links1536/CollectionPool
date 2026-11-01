using System.Collections.Concurrent;
using System.Collections.Generic;
using Links.CollectionPool.Collections.Concurrent;
using Links.CollectionPool.Providers.Abstractions;
using Links.CollectionPool.Providers.Core;

namespace Links.CollectionPool.Providers.Concurrent
{
	public class ConcurrentDictionaryPoolProvider<TKey, TValue>
		: CollectionPoolProvider<ConcurrentDictionaryPool<TKey, TValue>, ConcurrentDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>
		, IConcurrentDictionaryPoolProvider<TKey, TValue>
		where TKey : notnull
	{
	}
}
