using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour {

    public Animator d_animator;
    public GameObject worldScripts;
	// Use this for initialization
	void Start () {
        worldScripts = GameObject.Find("_WorldScripts");
        d_animator = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(worldScripts.GetComponent<Enemy_Spawner>().spawning)
        {
            d_animator.SetBool("Opened", true);
        }
        else
        {
            d_animator.SetBool("Opened", false);
        }
	}
}
