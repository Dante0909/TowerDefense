using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TowerAi : MonoBehaviour
{
    private GameManager instance;
    private WaveManager wmInstance;
    [SerializeField] private int id;
    protected Tower tower;
    protected Action attack;
    protected bool canShoot = true;
    protected float shotCooldown = 0;

    private Func<List<GameObject>, GameObject> findBloon;
    public List<GameObject> visibleBloons = new List<GameObject>();
    public GameObject target;
    private float angle;

    // Start is called before the first frame update
    protected void Begin()
    {
        instance = GameManager.instance;
        wmInstance = WaveManager.instance;
        ChangeTarget("First");
    }

    public void AddBloon(GameObject bloon)
    {
        visibleBloons.Add(bloon);
    }
    public void RemoveBloon(GameObject bloon)
    {
        if (target == bloon)
            target = null;
        visibleBloons.Remove(bloon);
    }

    public void ButtonUpgrade(int i)
    {
        if(i == 0)//path A
        {
            if (instance.CanAfford(tower.CostA))
                tower.UpgradeA(tower.CostA);//need to implement monkey village
        }
        else if(i == 1)//path B
        {
            if (instance.CanAfford(tower.CostB))
                tower.UpgradeB(tower.CostB);//need to implement monkey village
        }
    }
    public void ChangeTarget(string target)
    {
        switch (target)
        {
            case "First": findBloon = FindFirst;
                break;
            case "Last": findBloon = FindLast;
                break;
            case "Strong": findBloon = FindStrong;
                break;
            case "Close": findBloon = FindClose;
                break;
            default: findBloon = FindFirst;
                break;
        }
    }
    // Update is called once per frame
    protected void Tick()
    {
        if(visibleBloons.Count != 0)
        {
            if (target is null)
                target = findBloon(visibleBloons);

            Vector3 relative = transform.InverseTransformPoint(target.transform.position);
            angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.position - transform.position);

            if (shotCooldown < 0) shotCooldown += Time.deltaTime;
            else attack();


            
        }
        else { target = null; }
            
        
            
    }
    private GameObject FindFirst(List<GameObject> g)
    {
        float t;
        t = g.Select(svt => svt.GetComponent<Balloon>().DistanceTravelled).ToArray().Max();
        GameObject toReturn = g.Where(v => v.GetComponent<Balloon>().DistanceTravelled == t).First();
        //GameObject test = g.Where(v => v.GetComponent<Balloon>().CurrentWaypoint ==
        //    g.Select(svt => svt.GetComponent<Balloon>().CurrentWaypoint).ToArray().Max()).
        //    Where(svt => Vector2.Distance(instance.Waypoints[svt.GetComponent<Balloon>().CurrentWaypoint + 1].position, transform.position) ==
        //    g.Select(v => Vector2.Distance(instance.Waypoints[v.GetComponent<Balloon>().CurrentWaypoint + 1].position, transform.position)).ToArray().Min()).First();
        //GameObject test = 
        //    g.Where(v => v.GetComponent<Balloon>().CurrentWaypoint ==
        //    g.Select(svt => svt.GetComponent<Balloon>().CurrentWaypoint).ToArray().Max()).Select(v => v).
        //    

        return toReturn;
    }
    private GameObject FindLast(List<GameObject> g)
    {
        return null;
    }
    private GameObject FindStrong(List<GameObject> g)
    {
        return null;
    }
    private GameObject FindClose(List<GameObject> g)
    {
        return null;
    }
    private float FindAngle(Vector3 bloonP)
    {
        float vectorX = bloonP.x - transform.position.x;
        float vectorY = bloonP.y - transform.position.y;
        
        float scalarProduct = transform.up.x * vectorX + transform.up.y * vectorY;
        float normProduct = transform.up.magnitude * Vector2.Distance(bloonP, transform.position);

        float angle = Mathf.Acos(scalarProduct / normProduct);
        
        return SideOfVector(angle, bloonP);
    }
    private float SideOfVector(float angle, Vector3 bloonP)//checks if the bloon 
    {
        if ((bloonP.x - transform.position.x) * (transform.up.y - transform.position.y) * (bloonP.y - transform.position.y) * (transform.up.x - transform.position.x) < 0)
            angle = -angle;
        Debug.Log(angle);
        angle *= Mathf.Rad2Deg;
        return angle;
        
    }
    protected virtual void TriggerCooldown(float cd)
    {
        shotCooldown -= cd;
    }
   
}
