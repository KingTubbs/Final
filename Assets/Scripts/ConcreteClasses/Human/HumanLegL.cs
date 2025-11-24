using System.Collections.Generic;
using Interfaces.Abilities;
using Interfaces.Bodyparts;
using UnityEngine;

namespace Classes.Bodyparts
{
    public class HumanLegL: ILegL
{
    public string Species => "Human";
    public int HP => 10;
    public int Attack => 5;
    public int Speed => 5;

    public List<IActiveAbility> ActiveAbilities => new();

    public List<IPassiveAbility> PassiveAbilities => new();

    public Sprite Sprite { get; private set; }

    public HumanLegL(Sprite sprite)
    {
        Sprite = sprite;
    }

}
}