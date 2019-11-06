using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSounds : MonoBehaviour {

	public AudioClip zombieMoan;
	AudioSource audio;
	float MinWaitTime = 10.0f;
	float MaxWaitTime = 50.0f;
	float Rand;
	bool isActive;
	// Use this for initialization
	void Start () {
		Rand = 0;
		audio = this.gameObject.GetComponent<AudioSource> ();
		isActive = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (gameObject.GetComponent<EnemyBaseActions>().isAlive)
        {
            if (isActive == false)
            {
                Rand = Random.Range(MinWaitTime, MaxWaitTime);
                isActive = true;
            }

            if (isActive)
            {
                if (Rand <= 0)
                {
                    //	AudioSource.PlayClipAtPoint (zombieMoan, transform.position);
                    audio.clip = zombieMoan;
                    audio.Play();
                    isActive = false;
                }
                else
                {
                    Rand -= Time.deltaTime;
                }
            }
        }
	}



}
