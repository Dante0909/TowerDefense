using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DartMonkey : Tower, I_Upgrades
{
    public DartMonkey(TowerAi tower)
    {
        towerAi = tower;
        UpgradeA = PathA1;
        UpgradeB = PathB1;
        this.Damage = 1;
        this.Pierce = 4;
        this.CanSeeCamo = false;
        this.CanPopLead = false;
        upgradeCostA[0] = 90;
        upgradeCostA[1] = 120;
        upgradeCostA[2] = 500;
        upgradeCostA[3] = 1500;
        upgradeCostB[0] = 140;
        upgradeCostB[1] = 120;
        upgradeCostB[2] = 330;
        upgradeCostB[3] = 8000;
        this.CostA = upgradeCostA[0];
        this.BaseAttackSpeed = 0.8f;
    }

    private static int basePrice;
    public static int BasePrice { get => basePrice; set => basePrice = 200; }

    private static int baseRange;
    public static int BaseRange { get => baseRange; set => baseRange = 10; }


    public override Vector2 GetPos()
    {
        return new Vector2(this.posX, this.posY);
    }

    public string A1()
    {
        return "Makes the Dart Monkey shoot further than normal.";
    }

    public string A2()
    {
        return "Increase attack range even further and allows Dart Monkey to shoot Camo Bloons.";
    }

    public string A3()
    {
        return "Converts the Dart Monkey into a Spike-o-pult, a powerful tower that hurls a large spiked ball instead of darts. Good range, but slower attack speed. Each ball can pop up to 18 bloons.";
    }

    public string A4()
    {
        return "Hurls a giant unstoppable killer spiked ball that can pop lead bloons and excels at crushing ceramic bloons.";
    }

    public string B1()
    {
        return "Can pop 1 extra bloon per shot.";
    }

    public string B2()
    {
        return "Can pop 2 extra bloons per shot.";
    }

    public string B3()
    {
        return "Throws 3 darts at a time instad of 1.";
    }

    public string B4()
    {
        return "Super Monkey Fan Club Ability: Converts up to 10 nearby dart monkeys into Super Monkeys for 10 seconds.";
    }

    protected override void PathA1(int pricePaid)
    {
        this.Range *= 1.15f;
        base.PathA1(pricePaid);
    }

    protected override void PathA2(int pricePaid)
    {
        this.Range *= 1.15f;
        this.CanSeeCamo = true;
        base.PathA2(pricePaid);
    }

    protected override void PathA3(int pricePaid)
    {
        this.Pierce += 17;//total 18
        base.PathA3(pricePaid);
    }

    protected override void PathA4(int pricePaid)
    {
        this.Pierce += 82;//total 100
        this.CanPopLead = true;
        base.PathA4(pricePaid);
    }

    protected override void PathB1(int pricePaid)
    {
        this.Pierce += 1;
        base.PathB1(pricePaid);
    }

    protected override void PathB2(int pricePaid)
    {
        this.Pierce += 2;
        base.PathB2(pricePaid);
    }

    protected override void PathB3(int pricePaid)
    {
        base.PathB3(pricePaid);
    }

    protected override void PathB4(int pricePaid)
    {
        base.PathB4(pricePaid);
    }
}
