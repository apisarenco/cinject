namespace Cinject.Mapping.Generic {
	public class Mapper<T> : Cinject.Mapping.Mapper {
		public Mapper<T>() : base(typeof(T)) {

		}
	}
}