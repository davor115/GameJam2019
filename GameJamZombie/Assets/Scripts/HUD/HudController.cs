using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour {
    public GameObject Player;
    private float Player_Health;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Player_Health = Player.GetComponent<Movement>().p_health;
	}
}
