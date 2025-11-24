using Classes;
using Interfaces.Abilities;

public class ClawSwipe : IActiveAbility
{
    public string Name => "Claw Swipe";
    public float Cooldown => 1.2f; //influenced by total speed like 1.2 - 1* speed stat

    public void Execute(Monster user)
    {
        // insert  logic
    }
}