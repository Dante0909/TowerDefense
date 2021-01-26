using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StandardBalloon : Balloon
{

    private SpriteRenderer[] childSprites;
    private Vector4[] spriteColour;

    public override void SetData(SO data)
    {
        base.SetData(data);
        this.isCamo = data.isCamo;
        this.isRegen = data.isRegen;
        this.ChangeColor(this.type);
    }

    private void Awake()
    {
        childSprites = GetComponentsInChildren<SpriteRenderer>();
    }

    public void ChangeColor(EnumColours c)
    {
        type = c;
        Colours.coloursDictionary.TryGetValue(type, out spriteColour);
        for (int i = 0; i < childSprites.Length - 1; ++i)
        {
            childSprites[i].color = spriteColour[i];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        base.Begin();
    }

    // Update is called once per frame
    void Update()
    {
        base.Tick();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            int damage = collision.gameObject.GetComponent<ProjectileContact>().Damage;
            PopVFX g = PoolManager.SpawnObject(instance.PopEffect, transform.position, Quaternion.identity).GetComponent<PopVFX>();
            g.Death();
            base.Pop(damage);
            

        }
    }
}
