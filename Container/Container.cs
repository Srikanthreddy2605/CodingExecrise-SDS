using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> regTypes = new();

        public void Bind(Type abs, Type ctype)
        {
            if (!abs.IsAssignableFrom(ctype))
            {
                throw new ArgumentException($"{ctype.Name} not implementd {abs.Name}");
            }
            regTypes[abs] = ctype;
        }

        public T Get<T>()
        {
            var desiredType = typeof(T);
            if (!regTypes.ContainsKey(desiredType))
            {
                throw new InvalidOperationException($"Not Registered for type {desiredType.FullName}");
            }
            var actualImplementationType = regTypes[desiredType];
            return (T)Activator.CreateInstance(actualImplementationType)!;
        }
    }
}
