namespace Cinject.Mapping.Generic {
	public class Mapped<T> : Cinject.Mapping.Mapped {
		public Mapped() : base(typeof(T)) {}
	}
}