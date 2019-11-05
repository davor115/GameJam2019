﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Camera_Follow : MonoBehaviour {

    GameObject Player;
    public bool changingScene;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Hotel")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1f, transform.position.z);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Hotel")
        {
            Cam_FollowPlayer();
        }
        else if(scene.name == "City_Level")
        {
            City_Cam_Follow();
        }
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
    
    void City_Cam_Follow()
    {
        Vector3 move = new Vector3(Player.transform.position.x, Player.transform.position.y + 1f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, move, Time.deltaTime * 3.5f); // Speed of the movement
    }
}
