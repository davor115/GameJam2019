using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

    GameObject Player;
    public bool changingScene;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Cam_FollowPlayer();
	}

    void Cam_FollowPlayer()
    {
       if(changingScene)
        {
            // transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z);
            Vector3 move = new Vector3(transform.position.x, Player.transform.position.y + 1f, Player.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, move, Time.deltaTime * 3.5f); // Speed of the movement
        }
    }

    

}
