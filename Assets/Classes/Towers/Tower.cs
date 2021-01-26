using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower
{

    protected TowerAi towerAi;

    public static float basePercent = 0.8f;

    public int GetSellValue()
    {
        return sellValue;
    }
    protected virtual void SetSellValue(int val)
    {
        towerValue += val;
        sellValue = Mathf.FloorToInt(towerValue * basePercent/*monkey lab*/);
    }
    
    private int id;
    protected int posX;
    protected int posY;
    protected int sellValue;
    protected int towerValue;
    private float baseAttackSpeed;
    private string towerName;
    private float range;
    public float Range { get => range; set => range = value; }
    
    private int damageIncrease;
    private int terrainvalue;
    public struct towerPathA { };

    private bool canSeeCamo;
    public bool CanSeeCamo { get => canSeeCamo; set => canSeeCamo = value; }
    private bool canPopLead;
    public bool CanPopLead { get => canPopLead; set => canPopLead = value; }

    private int damage;//how many layers does the projectile pop
    public int Damage { get => damage; set => damage = value; }
    private int pierce;//how many bloons does the projectile go through
    public int Pierce { get => pierce; set => pierce = value; }

    protected int[] upgradeCostA = new int[4];
    protected int[] upgradeCostB = new int[4];

    public bool blockPathA;
    public bool blockPathB;
    private Action<int> upgradeA;
    private Action<int> upgradeB;
    private int costA;
    private int costB;
    public int CostA { get => costA; set => costA = value; }
    public int CostB { get => costB; set => costB = value; }
    public Action<int> UpgradeA { get => upgradeA; set => upgradeA = value; }
    public Action<int> UpgradeB { get => upgradeB; set => upgradeB = value; }
    public float BaseAttackSpeed { get => baseAttackSpeed; set => baseAttackSpeed = value; }

    //private Target target;
    private Enum specialties;
    private bool specialityActivated;

    
    public int GetID()
    {
        return id;
    }
    abstract public Vector2 GetPos();
    
    protected virtual void PathA1(int pricePaid)
    {
        SetSellValue(CostA);
        CostA = upgradeCostA[1];
        UpgradeA = PathA2;
    }
    protected virtual void PathA2(int pricePaid)
    {
        SetSellValue(CostA);
        CostA = upgradeCostA[2];
        UpgradeA = PathA3;
    }
    protected virtual void PathA3(int pricePaid)
    {
        SetSellValue(CostA);
        CostA = upgradeCostA[3];
        UpgradeA = PathA4;
    }
    protected virtual void PathA4(int pricePaid)
    {
        SetSellValue(CostA);
        CostA = int.MaxValue;
        UpgradeA = null;
    }
    protected virtual void PathB1(int pricePaid)
    {
        SetSellValue(CostB);
        CostB = upgradeCostB[1];
        UpgradeB = PathB2;
    }
    protected virtual void PathB2(int pricePaid)
    {
        SetSellValue(CostB);
        CostB = upgradeCostB[2];
        UpgradeB = PathB3;
    }
    protected virtual void PathB3(int pricePaid)
    {
        SetSellValue(CostB);
        CostB = upgradeCostB[3];
        UpgradeB = PathB4;
    }
    protected virtual void PathB4(int pricePaid)
    {
        SetSellValue(CostB);
        CostB = int.MaxValue;
        UpgradeB = null;
    }
    
}
