using Interfaces.Bodyparts;
using Interfaces.Abilities;
using System.Collections.Generic;

namespace Classes
{
public class Monster
{

    public IHead Head { get; set; }
    public IArmL LeftArm { get; set; }
    public IArmR RightArm { get; set; }
    public ILegL LeftLeg { get; set; }
    public ILegR RightLeg { get; set; }
    public ITorso Torso { get; set; }
    public int TotalHP => 
        Head.HP +
        Torso.HP +
        LeftArm.HP +
        RightArm.HP +
        LeftLeg.HP +
        RightLeg.HP;

    public int TotalAttack =>
        Head.Attack +
        Torso.Attack +
        LeftArm.Attack +
        RightArm.Attack +
        LeftLeg.Attack +
        RightLeg.Attack;

    public int TotalSpeed =>
        Head.Speed +
        Torso.Speed +
        LeftArm.Speed +
        RightArm.Speed +
        LeftLeg.Speed +
        RightLeg.Speed;

    //All abilities gathered from all parts

    private List<T> Combine<T>(params IEnumerable<T>[] sources)
    {
        var result = new List<T>();
        foreach (var src in sources)
            result.AddRange(src);
        return result;
    }
    public List<IActiveAbility> ActiveAbilities => Combine(
        Head.ActiveAbilities,
        LeftArm.ActiveAbilities,
        RightArm.ActiveAbilities,
        LeftLeg.ActiveAbilities,
        RightLeg.ActiveAbilities,
        Torso.ActiveAbilities
    );

    public List<IPassiveAbility> PassiveAbilities => Combine(
        Head.PassiveAbilities,
        LeftArm.PassiveAbilities,
        RightArm.PassiveAbilities,
        LeftLeg.PassiveAbilities,
        RightLeg.PassiveAbilities,
        Torso.PassiveAbilities
    );
}

}