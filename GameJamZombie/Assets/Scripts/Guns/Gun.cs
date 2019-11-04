using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public string gun_name;
    public int gun_magazine;
    public int gun_reserve;
    public int gun_damage;
    public float gun_fireRate;	
}
