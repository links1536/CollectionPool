using System.Collections.Generic;
using Links.CollectionPool.Collections.Generic;

namespace Links.CollectionPool.Providers.Abstractions
{
	public interface IListPoolProvider<T> : ICollectionPoolProvider<ListPool<T>, List<T>, T>
	{

	}
}
