using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance = null;
    
    private GameManager gmInstance;
    private JObject waveJson;//contains the wave information
    private List<Wave> waves = new List<Wave>();
    public List<GameObject> listOfBloons = new List<GameObject>();
    private int currentIndex = 14;
    

    private void Awake()
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

    [SerializeField] private GameObject standardBloon;
    [SerializeField] public SO[] sos;
    // Start is called before the first frame update
    void Start()
    {
        gmInstance = GameManager.instance;
        PoolManager.WarmPool(standardBloon, 15);

        if (Application.isEditor)
        {
            waveJson = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(@"assets\waveData.json"));
        }
        else
        {
            waveJson = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(@"waveData.json"));
        }
        
        for(int i = 0; i < waveJson.Count; ++i)
        {
            waves.Add(new Wave(waveJson[i.ToString()].ToObject<Dictionary<string, SpawnInfo>>().ToDictionary(x => x.Key, x => x.Value)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P)) sos[0].isCamo = true;
        if (Input.GetKeyDown(KeyCode.Alpha1)) PoolManager.SpawnObject(sos[0], Vector3.one, Quaternion.identity);
        
        
    }

    public void StartWave()
    {
        foreach (var typeOfBloons in waves[currentIndex].bloonsToSpawn)
        {
            StartCoroutine(Spawn(sos.Where(v => v.description == typeOfBloons.Key).First(), typeOfBloons.Value));

        }
        ++currentIndex;
    }

    private IEnumerator Spawn(SO b, SpawnInfo sInfo)
    {
        for(int i = 0; i < sInfo.amount; ++i)
        {
            
            yield return new WaitForSeconds(sInfo.delay.Length > i ? sInfo.delay[i] : 0.5f);
            listOfBloons.Add(PoolManager.SpawnObject(b, gmInstance.Waypoints[1].position, Quaternion.identity));
        }
    }
}

public class Wave
{
    public Wave(Dictionary<string, SpawnInfo> dic)
    {
        bloonsToSpawn = dic;
    }
    public Dictionary<string, SpawnInfo> bloonsToSpawn { get; set; }
    
    
}
public class SpawnInfo
{
    public int amount;
    public float[] delay;
}

