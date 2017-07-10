using System;

namespace Cinject.Mapping.Generic {
	public class Mapper<T> : Cinject.Mapping.Mapper {
		public Mapper(Func<Resolver, Resolver> resolverSetter) : base(resolverSetter) {
			base._tFrom = typeof(T);
		}

		public Mapped To<S>() {
			base._mapsTo = new Mapped<S>();
			return base._mapsTo;
		}
	}
}