using Microsoft.Extensions.Options;

namespace SerdehaBlog.Core.Helpers.Abstract
{
	public interface IWritableOptions<out T> : IOptionsSnapshot<T> where T : class, new()
	{
		void Update(Action<T> applyChanges);
	}
}
