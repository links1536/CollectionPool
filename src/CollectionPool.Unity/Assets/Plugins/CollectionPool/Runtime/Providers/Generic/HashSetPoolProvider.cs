using System.Collections.Generic;
using Links.CollectionPool.Collections.Generic;
using Links.CollectionPool.Providers.Abstractions;
using Links.CollectionPool.Providers.Core;

namespace Links.CollectionPool.Providers.Generic
{
	public class HashSetPoolProvider<T>
		: CollectionPoolProvider<HashSetPool<T>, HashSet<T>, T>
		, IHashSetPoolProvider<T>
	{
	}
}
