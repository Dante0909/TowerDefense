using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartMonkeyAi : TowerAi
{
    [SerializeField] private GameObject dart;
    [SerializeField] private Transform hand;
    // Start is called before the first frame update
    void Start()
    {
        base.Begin();
        tower = new DartMonkey(this);
        attack = TripleShotAttack;
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Tick();
        if (Input.GetKeyDown(KeyCode.I)) attack();
    }
    private void BaseAttack()
    {
        
    }
    private void UpgradedAttack()
    {

    }
    private void TripleShotAttack()
    {
        RotateHand();
        StartCoroutine(Dirty());
        TriggerCooldown(tower.BaseAttackSpeed);
        canShoot = false;   

    }
    private IEnumerator Dirty()//prevents the dart being spawned at the exact same time
    {
        for (int i = -1; i < 2; ++i)
        {
            ProjectileContact d = PoolManager.SpawnObject(dart, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + (15 * i))).GetComponent<ProjectileContact>();
            d.SetDirection(d.transform.up, tower.Damage, 9, tower.Pierce);
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    private void RotateHand()
    {
        hand.rotation = Quaternion.Euler(0, 0, 90);
        Invoke("CloseHand", 0.15f);
    }
    private void CloseHand()
    {
        hand.rotation = Quaternion.Euler(0, 0, 0);
    }

}
