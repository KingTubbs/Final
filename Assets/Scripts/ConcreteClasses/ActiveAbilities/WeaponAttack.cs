using Classes;
using Interfaces.Abilities;

public class WeaponAttack : IActiveAbility
{
    public string Name => "Weapon Attack";
    public float Cooldown => 1.2f; //maybe influenced by weapon

    public void Execute(Monster user)
    {
        // insert  logic
    }
}