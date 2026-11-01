using System.Collections.Concurrent;
using Links.CollectionPool.Collections.Abstractions;

namespace Links.CollectionPool.Collections.Core
{
	/// <summary>
	/// 型ごとのプールの実体を保持する内部クラス
	/// </summary>
	public static class CollectionPoolStorage
	{
		static readonly ConcurrentBag<ICollectionPool> m_CollectionPoolList = new ConcurrentBag<ICollectionPool>();

		internal static void Register(ICollectionPool instance)
		{
			m_CollectionPoolList.Add(instance);
		}

		public static void Clear()
		{
			// メモリの空き容量不足などをトリガーにクリアを走らせたい時用
			foreach (var collectionPool in m_CollectionPoolList)
			{
				collectionPool.Clear();
			}
		}
	}
}
