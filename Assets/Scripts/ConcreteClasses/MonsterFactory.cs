using Classes.Bodyparts;
using Classes;

public static class MonsterFactory
{
    public static Monster CreateHuman()
    {
        return new Monster
        {
            Head = new HumanHead(),
            Torso = new HumanTorso(),
            LeftArm = new HumanArmL(),
            RightArm = new HumanArmR(),
            LeftLeg = new HumanLegL(),
            RightLeg = new HumanLegR()
        };
    }

    public static Monster CreateWerewolf()
    {
        return new Monster
        {
            Head = new WerewolfHead(),
            Torso = new WerewolfTorso(),
            LeftArm = new WerewolfArmL(),
            RightArm = new WerewolfArmR(),
            LeftLeg = new WerewolfLegL(),
            RightLeg = new WerewolfLegR()
        };
    }

    // You can mix pieces later:
    public static Monster CreateHybrid()
    {
        return new Monster
        {
            Head = new HumanHead(),
            Torso = new WerewolfTorso(),
            LeftArm = new HumanArmL(),
            RightArm = new WerewolfArmR(),
            LeftLeg = new HumanLegL(),
            RightLeg = new WerewolfLegR()
        };
    }
}