using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Bloon", order = 1)]
public class SO : ScriptableObject
{
    
    public int speed;
    public int hp;
    public string description;
    public GameObject prefab;
    public EnumColours type;
    public bool isCamo;
    public bool isRegen;
    public int id;
}
