using System.Collections.Generic;
using Interfaces.Abilities;
using Interfaces.Bodyparts;

namespace Classes.Bodyparts
{
    public class WerewolfLegL: ILegL
{
    public string Species => "Werewolf";
    public int HP => 12;
    public int Attack => 8;
    public int Speed => 7;

    public List<IActiveAbility> ActiveAbilities => new();

    public List<IPassiveAbility> PassiveAbilities => new();
}
}