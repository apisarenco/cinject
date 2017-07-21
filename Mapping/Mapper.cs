using System;

namespace Cinject.Mapping {
	public sealed class Mapper {
		private Type _tFrom;
		private Mapped _mapsTo;

		public Mapper(Type tObject) {
			_tFrom = tObject;
		}

		public Mapped To(Type tObject) {
			_mapsTo = new Mapped(tObject);
			return _mapsTo;
		}

		public Mapped To<T>() {
			_mapsTo = new Mapped(typeof(T));
			return _mapsTo;
		}

		internal Type TFrom {get { return this._tFrom; }}

		internal Mapped MappedInfo {get { return this._mapsTo; }}
	}
}