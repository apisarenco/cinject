using Cinject.Mapping.Generic;

namespace Cinject {
	public abstract class BaseModule {
		protected Mapper<T> Map<T>() {
			return new Mapper<T>();
		}
	}
}