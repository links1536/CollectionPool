using System.Collections.Concurrent;
using System.Collections.Generic;
using Links.CollectionPool.Collections.Core;

namespace Links.CollectionPool.Collections.Concurrent
{
	/// <summary>
	/// ConcurrentDictionary用プールクラス
	/// </summary>
	public sealed class ConcurrentDictionaryPool<TKey, TValue> : CollectionPool<ConcurrentDictionaryPool<TKey, TValue>, ConcurrentDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>
		where TKey : notnull
	{
	}
}
