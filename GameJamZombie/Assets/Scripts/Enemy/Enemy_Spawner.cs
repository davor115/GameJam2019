using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy_Spawner : MonoBehaviour {
    // Define in unity editor.
    public GameObject[] Main_Spawner; // At the end of the corridor
    public GameObject[] Small_Spawner; // Multiple such as doors, windows, etc.

    public GameObject[] ZombiePrefabs; // Index 1: Normal, 2: Fast, 3: Tank

    bool FirstFloor;
    bool SecondFloor;
    bool ThirdFloor;

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
        Spawn();
    }

    void Spawn()
    {
       if(FirstFloor)
       {
            if (zombiecount > 0)
            {
                if (importantCooldown <= 0)
                {
                    Debug.Log("Spawn!");
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
                    Debug.Log("Spawn!");
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
            Instantiate(ZombiePrefabs[0], Main_Spawner[1].transform.position, Quaternion.identity);
            if (zombiecount > 0)
            {
                if (importantCooldown <= 0)
                {
                    Debug.Log("Spawn!");
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
                    Debug.Log("Spawn!");
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
            Instantiate(ZombiePrefabs[0], Main_Spawner[2].transform.position, Quaternion.identity);
            if (zombiecount > 0)
            {
                if (importantCooldown <= 0)
                {
                    Debug.Log("Spawn!");
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
                    Debug.Log("Spawn!");
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





}
