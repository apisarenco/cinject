using System;

namespace Cinject.Mapping {
	public class Mapper {
		protected internal Type _tFrom;
		protected internal Mapped _mapsTo;

		public Mapper() {
		}

		public Mapper(Type tObject) {
			_tFrom = tObject;
		}

		public Mapped To(Type tObject) {
			_mapsTo = new Mapped(tObject);
			return _mapsTo;
		}

		internal Type TFrom {get { return this._tFrom; }}

		internal Mapped MappedInfo {get { return this._mapsTo; }}
	}
}