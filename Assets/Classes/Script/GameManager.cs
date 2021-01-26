using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private static WaveManager wmInstance;
    [SerializeField] private GameObject waypointBase;

    [SerializeField] private GameObject popEffect;
    private Transform[] waypoints;
    public Transform[] Waypoints { get => waypoints; set => waypoints = value; }
    private void Awake()//singleton
    {
        if (!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private int money = 5000;
    public int Money { get => money; set => money = value; }
    public GameObject PopEffect { get => popEffect; set => popEffect = value; }

    public bool CanAfford(int price)
    {
        return price <= Money;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale *= 2;
        wmInstance = WaveManager.instance;
        Waypoints = waypointBase.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            wmInstance.StartWave();
        
    }
}
