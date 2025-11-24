using Classes.Bodyparts;
using Classes;
using Interfaces.Bodyparts;
using Interfaces.Abilities;
using UnityEngine;


public static class MonsterFactory
{
    public static Monster CreateHybrid()
    {
        // Load sprites (can be from Resources folder or assigned in inspector via a ScriptableObject)
        Sprite humanHeadSprite = Resources.Load<Sprite>("Sprites/Human/Head");
        Sprite werewolfArmLSprite = Resources.Load<Sprite>("Sprites/Werewolf/ArmL");
        Sprite humanArmRSprite = Resources.Load<Sprite>("Sprites/Human/ArmR");
        Sprite werewolfTorsoSprite = Resources.Load<Sprite>("Sprites/Werewolf/Torso");
        Sprite humanLegRSprite = Resources.Load<Sprite>("Sprites/Human/LegR");
        Sprite werewolfLegLSprite = Resources.Load<Sprite>("Sprites/Werewolf/LegL");

        // Create bodyparts with assigned sprites
        var head = new HumanHead(humanHeadSprite);
        var leftArm = new WerewolfArmL(werewolfArmLSprite);
        var rightArm = new HumanArmR(humanArmRSprite);
        var torso = new WerewolfTorso(werewolfTorsoSprite);
        var leftLeg = new WerewolfLegL(werewolfLegLSprite);
        var rightLeg = new HumanLegR(humanLegRSprite);
        // ... other bodyparts

        // Create monster
        Monster monster = new Monster
        {
            Head = head,
            LeftArm = leftArm,
            RightArm = rightArm,
            Torso = torso,
            LeftLeg = leftLeg,
            RightLeg = rightLeg
        };

        return monster;
    }
}