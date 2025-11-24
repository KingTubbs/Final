using Classes;
using Interfaces.Abilities;

public class Punch : IActiveAbility
{
    public string Name => "Punch";
    public float Cooldown => 1.0f;

    public void Execute(Monster user)
    {
        // insert  logic
    }
}