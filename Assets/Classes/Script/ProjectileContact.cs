using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileContact : MonoBehaviour
{
    private int damage;

    public int Damage { get => damage; set => damage = value; }
    private Vector2 direction;
    private int speed;
    private int hp;

    public void SetDirection(Vector2 direction, int damage, int speed, int hp)
    {
        this.direction = direction;
        this.Damage = damage;
        this.speed = speed;
        this.hp = hp;
        Invoke("Suicide", 0.25f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        --hp;
        if(hp <= 0)
        {
            CancelInvoke("Suicide");
            PoolManager.ReleaseObject(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
    private void Suicide()
    {
        PoolManager.ReleaseObject(this.gameObject);
    }
    
}
