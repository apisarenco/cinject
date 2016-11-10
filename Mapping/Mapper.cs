using System;

namespace Cinject.Mapping {
	public class Mapper {
		protected Type _tObject;

		public Mapper() {
			
		}

		public Mapper(Type tObject) {
			_tObject = tObject;
		}
	}
}