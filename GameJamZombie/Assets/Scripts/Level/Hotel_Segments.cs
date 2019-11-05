using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotel_Segments : MonoBehaviour {

    Enemy_Spawner enemy_spawner;
    GameObject p;
    GameObject _worldScripts;
	// Use this for initialization
	void Start ()
    {
        p = GameObject.FindGameObjectWithTag("Player");
        _worldScripts = GameObject.Find("_WorldScripts");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Stage_Finished_1")
        {
            if (p.GetComponent<Movement>().killCount >= 24)
            {
                _worldScripts.GetComponent<Enemy_Spawner>().FirstFloor = false;
                _worldScripts.GetComponent<Enemy_Spawner>().SecondFloor = true;
                _worldScripts.GetComponent<Enemy_Spawner>().zombiecount = 24;
                Camera.main.GetComponent<Camera_Follow>().changingScene = true;
                gameObject.transform.position = GameObject.Find("goTo_2").transform.position;
                transform.rotation = GameObject.Find("goTo_2").transform.rotation;
                
            }
        }
        else if(other.gameObject.name == "Stage_Finished_2")
        {
            if (p.GetComponent<Movement>().killCount >= 24)
            {
                _worldScripts.GetComponent<Enemy_Spawner>().SecondFloor = false;
                _worldScripts.GetComponent<Enemy_Spawner>().ThirdFloor = true;
                _worldScripts.GetComponent<Enemy_Spawner>().zombiecount = 24;
                Camera.main.GetComponent<Camera_Follow>().changingScene = true;
                gameObject.transform.position = GameObject.Find("goTo_3").transform.position;
                transform.rotation = GameObject.Find("goTo_3").transform.rotation;

            }
        }
        else if(other.gameObject.name == "Stage_Finished_3")
        {
            // Play exiting the building animation, Fade out, load next scene.
            if(p.GetComponent<Movement>().killCount >= 24)
            {
                // Load new Scene.
            }
        }
    }


}
