using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cinject.Mapping {
	public sealed class Mapped {
		private Type _tTo;
		private Lifetime _lifetime;
		private object _scope;
		private int _priority;

		private Func<object> _scopeRetriever;
		private Func<bool> _aliveEvaluator;
		private int _poolSize;

		private object _argumentValues;
		private object _argumentEvaluators;
		private ConstructorInfo _constructor;
		private ConstructorInfo _impliedConstructor;
		private Dictionary<string, Tuple<ParameterNature, object>> _constructorParameters;

		public Mapped(Type tObject) {
			_tTo = tObject;
		}

		internal int Priority {get {return _priority;}}

		internal Dictionary<string, Tuple<ParameterNature, object>> ConstructorParameters {
			get {
				if(_constructorParameters==null) {
					_constructorParameters = new Dictionary<string, Tuple<ParameterNature, object>>();
					if(_argumentValues!=null) {
						var tArgValues = _argumentValues.GetType();
						var pInfos = tArgValues.GetProperties();
						foreach(var pInfo in pInfos) {
							_constructorParameters.Add(pInfo.Name, Tuple.Create(ParameterNature.Value, pInfo.GetValue(_argumentValues)));
						}
					}
					if(_argumentEvaluators!=null) {
						var tArgEval = _argumentEvaluators.GetType();
						var pInfos = tArgEval.GetProperties();
						foreach(var pInfo in pInfos) {
							if(!_constructorParameters.ContainsKey(pInfo.Name)) {
								_constructorParameters.Add(pInfo.Name, Tuple.Create(ParameterNature.Evaluated, pInfo.GetValue(_argumentEvaluators)));
							}
						}
					}
				}
				return _constructorParameters;
			}
		}

		internal ConstructorInfo Constructor {
			get 
			{
				if(_constructor==null) {
					var constructors = _tTo.GetConstructors();
					foreach(var constr in constructors) {
						var pInfos = constr.GetParameters();
						var inject = constr.GetCustomAttributes(typeof(InjectAttribute)).FirstOrDefault();
						HashSet<string> injected = new HashSet<string>();
						if(inject!=null) {
							injected = ((InjectAttribute)inject).ParameterNames.ToHashSet();
						}
						var existing = ConstructorParameters;
						var invalidConstructor = false;
						foreach(var pInfo in pInfos) {
							if(!existing.ContainsKey(pInfo.Name) && !injected.Contains(pInfo.Name)) {
								invalidConstructor = true;
								break;
							}
						}
						if(invalidConstructor) {
							continue;
						}
						_constructor = constr;
						break;
					}
				}
				return _constructor;
			}
		}

		public Mapped WithPriority(int priority) {
			_priority = priority;
			return this;
		}

		public Mapped Singleton() {
			this._lifetime = Lifetime.Singleton;
			return this;
		}

		public Mapped Transient() {
			this._lifetime = Lifetime.Transient;
			return this;
		}

		public Mapped AttachedToScope(Func<object> scopeRetriever) {
			this._lifetime = Lifetime.Scope;
			this._scope = scopeRetriever();
			return this;
		}

		public Mapped AttachedToScope(Func<object> scopeRetriever, Func<bool> aliveEvaluator, int poolSize = 1) {
			this._lifetime = Lifetime.Scope;
			this._scopeRetriever = scopeRetriever;
			this._aliveEvaluator = aliveEvaluator;
			this._poolSize = poolSize;
			return this;
		}

		public Mapped WithConstructorArguments(object args) {
			_argumentValues = args;
			_constructorParameters = null;
			return this;
		}

		public Mapped WithConstructorArgumentEvaluators(object argEvaluators) {
			_argumentEvaluators = argEvaluators;
			_constructorParameters = null;
			return this;
		}

		public Mapped WithConstructorOverload(Type[] argumentTypes) {
			_constructor = _tTo.GetConstructor(argumentTypes);
			return this;
		}

		internal object Resolve(IKernel kernel) {
			
		}
	}
}