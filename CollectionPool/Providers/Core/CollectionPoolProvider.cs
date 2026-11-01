using System.Collections.Generic;
using Links.CollectionPool.Collections.Core;
using Links.CollectionPool.Providers.Abstractions;

namespace Links.CollectionPool.Providers.Core
{
	public class CollectionPoolProvider<TCollectionPool, TCollection, TItem> : ICollectionPoolProvider<TCollectionPool, TCollection, TItem>
		where TCollectionPool : CollectionPool<TCollectionPool, TCollection, TItem>, new()
		where TCollection : class, ICollection<TItem>, new()
	{
		TCollectionPool m_ObjectPool;

		public CollectionPoolProvider()
			=> m_ObjectPool = CollectionPool<TCollectionPool, TCollection, TItem>.Create();

		public TCollection Rent()
			=> m_ObjectPool.Rent();

		public CollectionPoolScope<TCollection, TItem> Rent(out TCollection instance)
			=> m_ObjectPool.Rent(out instance);

		public CollectionPoolScope<TCollection, TItem> Rent(out TCollection instance, bool clear = true)
			=> m_ObjectPool.Rent(out instance, clear);

		public void Return(TCollection instance, bool clear = true)
			=> m_ObjectPool.Return(instance, clear);
	}
}
