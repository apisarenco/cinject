using System;

namespace Cinject.Mapping {
    public class Mapped {
        protected Type _tTo;
        protected Lifetime _lifetime;
        protected object _scope;

        public Mapped(Type tObject) {
            _tTo = tObject;
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
            this._scope = scopeRetriever();
            return this;
        }
    }
}