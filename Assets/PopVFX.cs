using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopVFX : MonoBehaviour
{
    // Start is called before the first frame update

    public void Death()
    {
        StartCoroutine(Suicide());
    }
    private IEnumerator Suicide()
    {
        yield return new WaitForSeconds(0.08f);
        PoolManager.ReleaseObject(this.gameObject);
    }
} 
