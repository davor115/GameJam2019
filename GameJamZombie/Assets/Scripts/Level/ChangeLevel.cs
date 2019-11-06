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
    GameObject Train_DoubleDoor;
    GameObject LookAt_Train;
    float WaitForAnimTrain;

    bool isActive;

	// Use this for initialization
	void Start ()
    {
        isActive = false;
        LookAt_Train = GameObject.Find("Train_LookAt");
        WaitForAnimTrain = 4.0f;
        Train_DoubleDoor = GameObject.Find("Double_Doors");
        Player = GameObject.FindGameObjectWithTag("Player");
        final_Destination = GameObject.Find("Final_Destination");
	}
	
	// Update is called once per frame
	void Update ()
    {
       if(isActive)
        {
            _canvas.GetComponent<FadeScript>().FadeToLevel(3);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (Player.GetComponent<Movement>().killCount >= 24)
            {           
                if (scene.name == "Hotel")
                {
                    // SceneManager.LoadScene("City_Level");
                    Player.GetComponent<Movement>().killCount = 0;
                    _canvas.GetComponent<FadeScript>().FadeToLevel(1);
                    
                }
                else if (scene.name == "City_Level")
                {
                    //    SceneManager.LoadScene("Train_Station");
                    Player.GetComponent<Movement>().killCount = 0;
                    _canvas.GetComponent<FadeScript>().FadeToLevel(2);
                }               
                else if (scene.name == "Field")
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
                    if (Player.GetComponent<NavMeshAgent>().remainingDistance < 1.5f)
                    {
                        Debug.Log("Finished Game");
                        _canvas.GetComponent<FadeScript>().FadeToLevel(5);
                    }
                }
                else if(scene.name == "trainMoving")
                {
                    Player.GetComponent<Movement>().killCount = 0;
                    _canvas.GetComponent<FadeScript>().FadeToLevel(4);
                }
            }
           
        }
    }


    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "TrainStation" && Player.GetComponent<Movement>().killCount == 2)
            {
                Player.GetComponent<Movement>().enabled = false;
                Player.GetComponentInChildren<Gun_Controls>().enabled = false;
                Player.GetComponent<Rigidbody>().isKinematic = true;
                Player.GetComponent<Movement>().killCount = 0;
                Train_DoubleDoor.GetComponent<Animator>().SetBool("OpenTrainDoor", true);
                if (WaitForAnimTrain <= 0)
                {
                    Player.transform.LookAt(LookAt_Train.transform.position);
                    Player.transform.Translate(transform.forward * 1.5f * Time.deltaTime);
                    isActive = true;
                }
                else
                {
                    WaitForAnimTrain -= Time.deltaTime;
                }



            }
        }
    }


}
