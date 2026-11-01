using System.Collections.Generic;
using Links.CollectionPool.Collections.Generic;
using Links.CollectionPool.Providers.Abstractions;
using Links.CollectionPool.Providers.Core;

namespace Links.CollectionPool.Providers.Generic
{
	public class ListPoolProvider<T>
		: CollectionPoolProvider<ListPool<T>, List<T>, T>
		, IListPoolProvider<T>
	{
	}
}
