using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerVision : MonoBehaviour
{
    private TowerAi towerAi;
    // Start is called before the first frame update
    void Start()
    {
        towerAi = GetComponentInParent<TowerAi>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        towerAi.AddBloon(collision.gameObject);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        towerAi.RemoveBloon(collision.gameObject);
    }
}
