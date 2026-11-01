using System.Collections.Generic;
using Links.CollectionPool.Collections.Core;

namespace Links.CollectionPool.Collections.Generic
{
	/// <summary>
	/// Dictionary用プールクラス
	/// </summary>
	public sealed class DictionaryPool<TKey, TValue> : CollectionPool<DictionaryPool<TKey, TValue>, Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>
		where TKey : notnull
	{
	}
}
