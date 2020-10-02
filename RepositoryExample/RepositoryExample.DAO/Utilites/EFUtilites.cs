using System.Collections.Generic;
using System.Linq;

namespace RepositoryExample.DAO.Utilites
{
	/// <summary>
	/// EF Core utilites
	/// </summary>
	public class EfUtilites
	{
		/// <summary>
		/// Limit memory consumption in case we are using  IEnumerable instead of IQueryable ( use "foreach" - as example)
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entityQueryable">any  of IQueryable</param>
		/// <param name="size">maximum size of T array will be selected to the memory</param>
		/// <returns></returns>
		public static IEnumerable<T> QueryByChunk<T>( IQueryable<T> entityQueryable, int size)
		{
			return QueryChunksOfSize(entityQueryable,size).SelectMany(chunk => chunk);
		}

		private static IEnumerable<T[]> QueryChunksOfSize<T>( IQueryable<T> entityQueryable, int size)
		{
			int chunkNumber = 0;

			while (true)
			{
				var skipped = (chunkNumber == 0)
					? entityQueryable
					: entityQueryable.Skip(chunkNumber * size);

				var chunkTaked = skipped.Take(size).ToArray();

				if (chunkTaked.Length == 0)
				{
					yield break;
				}

				yield return chunkTaked;

				chunkNumber++;
			}
		}
    }
}
