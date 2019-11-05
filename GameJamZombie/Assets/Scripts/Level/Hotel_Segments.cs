using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotel_Segments : MonoBehaviour {

    Enemy_Spawner enemy_spawner;
    GameObject p;
	// Use this for initialization
	void Start ()
    {
        p = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Stage_Finished_1")
        {
            if (p.GetComponent<Movement>().killCount >= 3)
            {
                gameObject.transform.position = GameObject.Find("goTo_2").transform.position;
                transform.rotation = GameObject.Find("goTo_2").transform.rotation;
                
            }
        }
        else if(other.gameObject.name == "Stage_Finished_2")
        {

        }
        else if(other.gameObject.name == "Stage_Finished_3")
        {

        }
    }


}
