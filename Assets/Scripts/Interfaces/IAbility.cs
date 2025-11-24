using Classes;

namespace Interfaces.Abilities
{


public interface IAbility
    {
        string Name { get; }

    }
public interface IActiveAbility : IAbility
{
    void Execute(Monster user);
    float Cooldown { get; }
}

public interface IPassiveAbility : IAbility
{
    void Apply(Monster user); // called automatically, or conditionally
    float Cooldown { get; }
}

}