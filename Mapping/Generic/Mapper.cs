namespace Cinject.Mapping.Generic {
	public class Mapper<T> : Cinject.Mapping.Mapper {
		public Mapper() {
			base._tObject = typeof(T);
		}
	}
}