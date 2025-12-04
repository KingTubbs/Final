namespace Interfaces.Bodyparts
{
    using System.Collections.Generic;
    using Interfaces.Abilities;
    using Classes;
public interface IBodypart
{
    string Species { get; }
    int HP { get; }
    int Attack { get; }
    int Speed { get; }

    List<IActiveAbility> ActiveAbilities { get; }
    List<IPassiveAbility> PassiveAbilities { get; }

    UnityEngine.Sprite Sprite { get; }
}
}