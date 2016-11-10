using System;

namespace Cinject {
	public interface IKernel {
		void RegisterModule(BaseModule module);
		T Get<T>();
		object Get(Type tObject);
	}
}