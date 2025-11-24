using Classes.Bodyparts;
using Classes;
using Interfaces.Bodyparts;
using Interfaces.Abilities;
using UnityEngine;


public static class MonsterFactory
{
    public static Monster CreateRandomHybrid()
    {
        // Load sprites
        Sprite humanHeadSprite = Resources.Load<Sprite>("Sprites/BodyParts/Human/Head");
        Sprite werewolfHeadSprite = Resources.Load<Sprite>("Sprites/BodyParts/Werewolf/Head");
        Sprite humanArmLSprite = Resources.Load<Sprite>("Sprites/BodyParts/Human/LeftArm");
        Sprite werewolfArmLSprite = Resources.Load<Sprite>("Sprites/BodyParts/Werewolf/LeftArm");
        Sprite humanArmRSprite = Resources.Load<Sprite>("Sprites/BodyParts/Human/RightArm");
        Sprite werewolfArmRSprite = Resources.Load<Sprite>("Sprites/BodyParts/Werewolf/RightArm");
        Sprite humanTorsoSprite = Resources.Load<Sprite>("Sprites/BodyParts/Human/Torso");
        Sprite werewolfTorsoSprite = Resources.Load<Sprite>("Sprites/BodyParts/Werewolf/Torso");
        Sprite humanLegLSprite = Resources.Load<Sprite>("Sprites/BodyParts/Human/LeftLeg");
        Sprite werewolfLegLSprite = Resources.Load<Sprite>("Sprites/BodyParts/Werewolf/LeftLeg");
        Sprite humanLegRSprite = Resources.Load<Sprite>("Sprites/BodyParts/Human/RightLeg");
        Sprite werewolfLegRSprite = Resources.Load<Sprite>("Sprites/BodyParts/Werewolf/RightLeg");

        // Randomly pick human or werewolf for each part
        IHead head = Random.value > 0.5f ? new HumanHead(humanHeadSprite) : new WerewolfHead(werewolfHeadSprite);
        IArmL leftArm = Random.value > 0.5f ? new HumanArmL(humanArmLSprite) : new WerewolfArmL(werewolfArmLSprite);
        IArmR rightArm = Random.value > 0.5f ? new HumanArmR(humanArmRSprite) : new WerewolfArmR(werewolfArmRSprite);
        ITorso torso = Random.value > 0.5f ? new HumanTorso(humanTorsoSprite) : new WerewolfTorso(werewolfTorsoSprite);
        ILegL leftLeg = Random.value > 0.5f ? new HumanLegL(humanLegLSprite) : new WerewolfLegL(werewolfLegLSprite);
        ILegR rightLeg = Random.value > 0.5f ? new HumanLegR(humanLegRSprite) : new WerewolfLegR(werewolfLegRSprite);

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