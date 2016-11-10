using System;

namespace Cinject {
	public class Kernel : IKernel {
		public void RegisterModule(BaseModule module) {
			
		}

		public T Get<T>() {
			throw new NotImplementedException();
		}

		public object Get(Type tObject) {
			throw new NotImplementedException();
		}
	}
}