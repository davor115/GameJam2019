using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class ChangeLevel : MonoBehaviour {

    GameObject Player;
    public GameObject _canvas;
    GameObject train_door;
    GameObject final_Destination;
	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        final_Destination = GameObject.Find("Final_Destination");
	}
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Player.GetComponent<Movement>().killCount >= 24)
            {
                Scene scene = SceneManager.GetActiveScene();
                if (scene.name == "Hotel")
                {
                   // SceneManager.LoadScene("City_Level");
                    _canvas.GetComponent<FadeScript>().FadeToLevel(1);
                }
                else if (scene.name == "City_Level")
                {
                    //    SceneManager.LoadScene("Train_Station");
                    _canvas.GetComponent<FadeScript>().FadeToLevel(2);
                }
                else if(scene.name == "TrainStation")
                {
                    Player.GetComponent<Movement>().enabled = false;
                    
                }
                else if(scene.name == "Field")
                {
                    Player.GetComponent<Movement>().enabled = false;
                    Player.GetComponentInChildren<Gun_Controls>().enabled = false;
                    Player.transform.LookAt(final_Destination.transform);
                    Player.AddComponent<NavMeshAgent>();
                    Player.GetComponent<NavMeshAgent>().baseOffset = 0.9f;
                    Player.GetComponent<NavMeshAgent>().speed = 1;
                    Player.GetComponent<NavMeshAgent>().height = 1.5f;
                    Player.GetComponent<NavMeshAgent>().radius = 0.5f;

                   

                    Player.GetComponent<NavMeshAgent>().SetDestination(final_Destination.transform.position);
                    if(Player.GetComponent<NavMeshAgent>().remainingDistance < 1.5f)
                    {
                        Debug.Log("Finished Game");
                    }
                }
            }
        }
    }

}
