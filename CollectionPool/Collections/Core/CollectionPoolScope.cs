using System;
using System.Collections.Generic;
using Links.CollectionPool.Collections.Abstractions;

namespace Links.CollectionPool.Collections.Core
{
	/// <summary>
	/// コレクションの寿命を管理するScope
	/// </summary>
	public struct CollectionPoolScope<TCollection, TItem> : IDisposable
		where TCollection : class, ICollection<TItem>, new()
	{
		readonly ICollectionPool<TCollection, TItem> m_Pool;
		readonly bool m_Clear;
		TCollection? m_Instance;

		internal CollectionPoolScope(ICollectionPool<TCollection, TItem> collectionPool, TCollection instance, bool clear)
		{
			m_Pool = collectionPool;
			m_Instance = instance;
			m_Clear = clear;
		}

		public void Dispose()
		{
			if (m_Pool != null && m_Instance != null)
			{
				var instance = m_Instance;
				m_Instance = null;
				m_Pool.Return(instance, m_Clear);
			}
		}
	}
}
