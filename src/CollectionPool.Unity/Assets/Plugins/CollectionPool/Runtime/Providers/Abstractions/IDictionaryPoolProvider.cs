using System.Collections.Generic;
using Links.CollectionPool.Collections.Generic;

namespace Links.CollectionPool.Providers.Abstractions
{
	public interface IDictionaryPoolProvider<TKey, TValue> : ICollectionPoolProvider<DictionaryPool<TKey, TValue>, Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>
		where TKey : notnull
	{

	}
}
