using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African,
        European
    }
    public enum SwallowLoad
    {
        None,
        Coconut
    }
    public abstract class Swallow
    {
        public SwallowLoad Load { get; }
        protected Swallow(SwallowLoad load)
        {
            Load = load;
        }
        public abstract double GetAirspeedVelocity();
    }

    public class AfricanSwallow : Swallow
    {
        public AfricanSwallow(SwallowLoad load) : base(load) { }
        public override double GetAirspeedVelocity() => Load switch
        {
            SwallowLoad.None => 22,
            SwallowLoad.Coconut => 18,
            _ => throw new InvalidOperationException($"NotSupported load '{Load}' for African Swallow.")
        };
    }
    public class EuropeanSwallow : Swallow
    {
        public EuropeanSwallow(SwallowLoad load) : base(load) { }
        public override double GetAirspeedVelocity() => Load switch
        {
            SwallowLoad.None => 20,
            SwallowLoad.Coconut => 16,
            _ => throw new InvalidOperationException($"NotSupported load '{Load}' for European Swallow.")
        };
    }
    //Factor class for creating Swallow instances
    public static class SwallowFactory
    {
        public static Swallow GetSwallowInstance(SwallowType type, SwallowLoad load) => type switch
        {
            SwallowType.African => new AfricanSwallow(load),
            SwallowType.European => new EuropeanSwallow(load),
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"NotSupported swallow type: {type}")
        };
    }
}
