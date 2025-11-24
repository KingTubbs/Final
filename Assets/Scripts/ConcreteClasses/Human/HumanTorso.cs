using System.Collections.Generic;
using Interfaces.Abilities;
using Interfaces.Bodyparts;
using UnityEngine;

namespace Classes.Bodyparts
{
    public class HumanTorso: ITorso
{
    public string Species => "Human";
    public int HP => 10;
    public int Attack => 5;
    public int Speed => 5;

    public List<IActiveAbility> ActiveAbilities => new();

    public List<IPassiveAbility> PassiveAbilities => new();

    public Sprite Sprite { get; private set; }

    public HumanTorso(Sprite sprite)
    {
        Sprite = sprite;
    }


}
}