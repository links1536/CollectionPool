using System.Collections.Generic;
using Links.CollectionPool.Collections.Core;

namespace Links.CollectionPool.Providers.Abstractions
{
	public interface ICollectionPoolProvider<TCollectionPool, TCollection, TItem>
		where TCollectionPool : CollectionPool<TCollectionPool, TCollection, TItem>, new()
		where TCollection : class, ICollection<TItem>, new()
	{
		TCollection Rent();

		CollectionPoolScope<TCollection, TItem> Rent(out TCollection instance);

		CollectionPoolScope<TCollection, TItem> Rent(out TCollection instance, bool clear = true);

		void Return(TCollection instance, bool clear = true);
	}
}
