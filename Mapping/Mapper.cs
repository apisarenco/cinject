using System;

namespace Cinject.Mapping {
	public class Mapper {
		protected Type _tFrom;
		protected Mapped _mapsTo;

		public Mapper(Func<Resolver, Resolver> resolverSetter) {
			resolverSetter(new Resolver());
		}

		public Mapper(Type tObject) {
			_tFrom = tObject;
		}

		public Mapped To(Type tObject) {
			_mapsTo = new Mapped(tObject);
			return _mapsTo;
		}
	}
}