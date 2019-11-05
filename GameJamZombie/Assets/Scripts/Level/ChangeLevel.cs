using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour {

    GameObject Player;
    public GameObject _canvas;
    GameObject train_door;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
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
            }
        }
    }

}
