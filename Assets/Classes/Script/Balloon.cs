using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Balloon : MonoBehaviour
{
    protected GameManager instance;
    protected int hp;
    protected EnumColours type;
    protected int speed;
    private int id;
    private int currentWaypoint = 1;//starts at 1 since 0 is the position of the root object
    private Vector3 nextWayPoint;
    protected bool isCamo;
    protected bool isRegen;
    private float distanceTravelled = 0;
    private WaveManager wmInsance;

    public int CurrentWaypoint { get => currentWaypoint; set => currentWaypoint = value; }
    public float DistanceTravelled { get => distanceTravelled; set => distanceTravelled = value; }

    protected void Begin()
    {
        instance = GameManager.instance;
        wmInsance = WaveManager.instance;
        SetNextWaypoint(CurrentWaypoint);
        
    }
    protected void Tick()
    {
        Vector2 previousPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, nextWayPoint, speed * Time.deltaTime);
        DistanceTravelled += Vector2.Distance(transform.position, previousPos);


        if (transform.position == nextWayPoint)
            SetNextWaypoint(CurrentWaypoint);
    }
    private void SetNextWaypoint(int cw)
    {
        nextWayPoint = instance.Waypoints[cw + 1].position;
        ++CurrentWaypoint;
    }
    public virtual void SetData(SO data)
    {
        this.type = data.type;
        this.hp = data.hp;
        this.speed = data.speed;
        this.id = data.id;
    }
    
    public virtual void Hit(int damage)
    {
        hp -= damage;
        PoolManager.ReleaseObject(this.gameObject);
    }
    
    protected void Pop(int d)
    {
        int temp = hp - d;
        if (d >= hp) 
        {
            distanceTravelled = 0;
            currentWaypoint = 0;
            SetNextWaypoint(CurrentWaypoint);
            PoolManager.ReleaseObject(this.gameObject);

        } 
        else SetData(wmInsance.sos.Where(v => v.hp == temp).First());
        
    }

}
