using System.Collections.Generic;
using Links.CollectionPool.Collections.Core;

namespace Links.CollectionPool.Collections.Abstractions
{
	public interface ICollectionPool
	{
		void Clear();
	}

	public interface ICollectionPool<TCollection, TItem> : ICollectionPool
		where TCollection : class, ICollection<TItem>, new()
	{
		TCollection Rent();

		CollectionPoolScope<TCollection, TItem> Rent(out TCollection instance);

		CollectionPoolScope<TCollection, TItem> Rent(out TCollection instance, bool clear = true);

		void Return(TCollection instance, bool clear = true);
	}
}
