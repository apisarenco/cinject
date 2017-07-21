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

		protected Mapper Map<T>() {
			var mapper = new Mapper(typeof(T));
			_mappers.Add(mapper);
			return mapper;
		}

		protected Mapper Map(Type tObject) {
			var mapper = new Mapper(tObject);
			_mappers.Add(mapper);
			return mapper;
		}

		internal Dictionary<Type, List<Tuple<int, Type>>> Rules
		{
			get
			{
				var result = new Dictionary<Type, List<Tuple<int, Type>>>();
				foreach(var mapper in _mappers) {
					var tFrom = mapper.TFrom;
					if(!result.ContainsKey(tFrom)) {
						result.Add(tFrom, new List<Tuple<int, Type>>());
					}
					var mInfo = mapper.MappedInfo;
					
				}
				return result;
			}
		}
	}
}