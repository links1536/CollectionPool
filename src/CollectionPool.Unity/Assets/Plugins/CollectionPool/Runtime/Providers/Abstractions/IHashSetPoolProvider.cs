using System.Collections.Generic;
using Links.CollectionPool.Collections.Generic;

namespace Links.CollectionPool.Providers.Abstractions
{
	public interface IHashSetPoolProvider<T> : ICollectionPoolProvider<HashSetPool<T>, HashSet<T>, T>
	{

	}
}
