using System;

namespace Cinject {
	public interface IKernel {
		void RegisterModule(BaseModule module, int priority);
		T Get<T>();
		object Get(Type tObject);
	}
}