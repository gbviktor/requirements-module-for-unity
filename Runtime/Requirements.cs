using System;

using MontanaGames.Systems.Requerments;

namespace MontanaGames.Systems.Requirements
{
    [Serializable]
    public struct Requirement : IComparable<Requirement>
    {
        public string id;
        public Activation Activation;
        public int value;

        public int CompareTo(Requirement other)
        {
            return id == other.id && Activation == other.Activation && value == other.value ? 0 : 1;
        }
    }
    public interface IActivation
    {
        public bool IsSatisfied(int currentValue, int requiredValue);
    }

    [Serializable]
    public class IS_EQALS_TO : IActivation
    {
        public bool IsSatisfied(int currentValue, int requiredValue)
        {
            return currentValue == requiredValue;
        }
    }
    public class NOT_EQUALS_TO : IActivation
    {
        bool IActivation.IsSatisfied(int currentValue, int requiredValue)
        {
            return currentValue != requiredValue;
        }
    }

    public class IS_LESS_THAT : IActivation
    {
        bool IActivation.IsSatisfied(int currentValue, int requiredValue)
            => currentValue < requiredValue;
    }
    public class IS_GREATER_THAT : IActivation
    {
        bool IActivation.IsSatisfied(int currentValue, int requiredValue)
            => (currentValue > requiredValue);
    }
}