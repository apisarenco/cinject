using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinject {
    public class InjectAttribute : Attribute {
        private string[] _parameterNames;
        public InjectAttribute(params string[] parameterNames) {
            _parameterNames = parameterNames;
        }

        internal IEnumerable<string> ParameterNames {get {return _parameterNames.AsEnumerable();}}
    }
}