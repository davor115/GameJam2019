using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy_Spawner : MonoBehaviour {

    bool Hotel;
    bool City;
    bool Train;
    bool Field;


    // Define in unity editor.
    public GameObject[] Main_Spawner; // At the end of the corridor
    public GameObject[] Small_Spawner; // Multiple such as doors, windows, etc.

    public GameObject[] ZombiePrefabs; // Index 1: Normal, 2: Fast, 3: Tank

    public bool FirstFloor;
    public bool SecondFloor;
    public bool ThirdFloor;

    public bool spawning;

    public int zombiecount;
    public float importantCooldown;
    float smallCooldown;
	// Use this for initialization
	void Start ()
    {
        spawning = true;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Hotel")
        {
            Hotel = true;
            importantCooldown = 4.0f;
            smallCooldown = 7.0f;
            zombiecount = 24;
        }

        FirstFloor = true;
        SecondFloor = false;
        ThirdFloor = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Hotel)
        {
            Spawn();
        }
        else
        {
            CityWorld();
        }
    }

    void Spawn()
    {
       if(FirstFloor)
       {
            if (zombiecount > 0)
            {
                if (importantCooldown <= 0)
                {
                 //   Debug.Log("Spawn!");
                    Instantiate(ZombiePrefabs[0], Main_Spawner[0].transform.position, Quaternion.identity);
                    zombiecount -= 1;
                    importantCooldown = 4.0f;
                }
                else
                {
                    importantCooldown -= Time.deltaTime;
                }

                if (smallCooldown <= 0)
                {
                  //  Debug.Log("Spawn!");
                    int r = Random.Range(0, 1);
                    Instantiate(ZombiePrefabs[0], Small_Spawner[r].transform.position, Quaternion.identity);
                    zombiecount -= 1;
                    smallCooldown = 7.0f;
                }
                else
                {
                    smallCooldown -= Time.deltaTime;
                }
            }


       }
       else if(SecondFloor)
       {          
            if (zombiecount > 0)
            {
                if (importantCooldown <= 0)
                {
                   // Debug.Log("Spawn!");
                    Instantiate(ZombiePrefabs[0], Main_Spawner[1].transform.position, Quaternion.identity);
                    zombiecount -= 1;
                    importantCooldown = 4.0f;
                }
                else
                {
                    importantCooldown -= Time.deltaTime;
                }

                if (smallCooldown <= 0)
                {
                  //  Debug.Log("Spawn!");
                    int r = Random.Range(2, 3);
                    Instantiate(ZombiePrefabs[0], Small_Spawner[r].transform.position, Quaternion.identity);
                    zombiecount -= 1;
                    smallCooldown = 7.0f;
                }
                else
                {
                    smallCooldown -= Time.deltaTime;
                }
            }
        }
       else if(ThirdFloor)
       {           
            if (zombiecount > 0)
            {
                if (importantCooldown <= 0)
                {
                   // Debug.Log("Spawn!");
                    Instantiate(ZombiePrefabs[0], Main_Spawner[2].transform.position, Quaternion.identity);
                    zombiecount -= 1;
                    importantCooldown = 4.0f;
                }
                else
                {
                    importantCooldown -= Time.deltaTime;
                }

                if (smallCooldown <= 0)
                {
                 //   Debug.Log("Spawn!");
                    int r = Random.Range(4, 5);
                    Instantiate(ZombiePrefabs[0], Small_Spawner[r].transform.position, Quaternion.identity);
                    zombiecount -= 1;
                    smallCooldown = 7.0f;
                }
                else
                {
                    smallCooldown -= Time.deltaTime;
                }
            }
        }
    }

    void CityWorld()
    {
        if (zombiecount > 0)
        {
            if (importantCooldown <= 0)
            {
                //   Debug.Log("Spawn!");
                int rand = Random.Range(0, Main_Spawner.Length);
                Instantiate(ZombiePrefabs[0], Main_Spawner[rand].transform.position, Quaternion.identity);
                zombiecount -= 1;
                importantCooldown = 4.0f;
            }
            else
            {
                importantCooldown -= Time.deltaTime;
            }

            if (smallCooldown <= 0)
            {
                //  Debug.Log("Spawn!");
                int r = Random.Range(0, Small_Spawner.Length);
                Instantiate(ZombiePrefabs[0], Small_Spawner[r].transform.position, Quaternion.identity);
                zombiecount -= 1;
                smallCooldown = 7.0f;
            }
            else
            {
                smallCooldown -= Time.deltaTime;
            }
        }
    }



}
