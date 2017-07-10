using System;
using System.Collections.Generic;

namespace Cinject {
	public class Kernel : IKernel {
		private List<BaseModule> _modules;
		public Kernel() {
			_modules = new List<BaseModule>();
		}

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