using System;
using System.Collections.Generic;
using Cinject.Mapping;
using Cinject.Mapping.Generic;

namespace Cinject {
	public abstract class BaseModule {
		private List<Mapper> _mappers;

		public BaseModule() {
			_mappers = new List<Mapper>();
		}

		protected Mapper<T> Map<T>() {
			var mapper = new Mapper<T>();
			_mappers.Add(mapper);
			return mapper;
		}

		protected Mapper Map(Type tObject) {
			var mapper = new Mapper(tObject);
			_mappers.Add(mapper);
			return mapper;
		}
	}
}