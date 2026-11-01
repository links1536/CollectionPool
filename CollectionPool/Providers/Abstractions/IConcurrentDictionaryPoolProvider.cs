using System.Collections.Concurrent;
using System.Collections.Generic;
using Links.CollectionPool.Collections.Concurrent;

namespace Links.CollectionPool.Providers.Abstractions
{
	public interface IConcurrentDictionaryPoolProvider<TKey, TValue> : ICollectionPoolProvider<ConcurrentDictionaryPool<TKey, TValue>, ConcurrentDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>
		where TKey : notnull
	{

	}
}
