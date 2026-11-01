using System;
using System.Collections.Generic;
using System.Threading;
using Links.CollectionPool.Collections.Abstractions;

namespace Links.CollectionPool.Collections.Core
{
	/// <summary>
	/// コレクションプールの基底クラス
	/// </summary>
	public class CollectionPool<TCollectionPool, TCollection, TItem> : ICollectionPool<TCollection, TItem>
		where TCollectionPool : CollectionPool<TCollectionPool, TCollection, TItem>, new()
		where TCollection : class, ICollection<TItem>, new()
	{
		public static TCollectionPool Shared { get; } = Create();

		public static TCollectionPool Create()
		{
			var collectionPool = new TCollectionPool();
			CollectionPoolStorage.Register(collectionPool);
			return collectionPool;
		}

		TCollection? m_FastItem;
		TCollection?[] m_Items;

		protected CollectionPool()
		{
			int processCount = Environment.ProcessorCount;
			int defaultCapacity = processCount * 2;
			m_Items = new TCollection[defaultCapacity];
		}

		public TCollection Rent()
		{
			var instance = m_FastItem;
			if (instance != null && Interlocked.CompareExchange(ref m_FastItem, null, instance) == instance)
			{
				return instance;
			}

			// 配列から空きを探す
			var items = m_Items;
			for (int i = 0; i < items.Length; i++)
			{
				instance = items[i];
				if (instance != null && Interlocked.CompareExchange(ref items[i], null, instance) == instance)
				{
					return instance;
				}
			}

			// プールが空なら新規作成
			return new TCollection();
		}

		public CollectionPoolScope<TCollection, TItem> Rent(out TCollection instance)
		{
			instance = Rent();
			return new CollectionPoolScope<TCollection, TItem>(this, instance, true);
		}

		public CollectionPoolScope<TCollection, TItem> Rent(out TCollection instance, bool clear = true)
		{
			instance = Rent();
			return new CollectionPoolScope<TCollection, TItem>(this, instance, clear);
		}

		public void Return(TCollection instance, bool clear = true)
		{
			if (clear)
				instance.Clear();

			if (m_FastItem == null && Interlocked.CompareExchange(ref m_FastItem, instance, null) == null)
				return;

			// 配列の空きスロットに戻す
			var items = m_Items;
			for (int i = 0; i < items.Length; i++)
				if (items[i] == null && Interlocked.CompareExchange(ref items[i], instance, null) == null)
					return;

			// 返さない
		}

		void ICollectionPool.Clear()
		{
			m_FastItem = null;
			var items = m_Items;
			Array.Clear(items);
		}
	}
}
