using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    Animator anim;
    public Player pl;


	// Use this for initialization
	void Start ()
    {
        anim = this.gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Die()
    {
        anim.SetBool("isDead", true);
        // End game.
    }

    public void Walking()
    {

        anim.SetBool("isWalking", true);
        anim.SetBool("isWalkingBackwards", false);
        anim.SetBool("isHit", false);
        anim.SetBool("isIdle", false);
    }

    public void WalkBackwards()
    {
        anim.SetBool("isWalkingBackwards", true);
        anim.SetBool("isWalking", false);
        anim.SetBool("isHit", false);
        anim.SetBool("isIdle", false);
    }

    public void isHit()
    {
        anim.SetBool("isHit", true);
        anim.SetBool("isHit", false); // Maybe it will get hit and then go idle?
    }

    public void Idle()
    {
        anim.SetBool("isIdle", true);
        anim.SetBool("isWalking", false);
        anim.SetBool("isWalkingBackwards", false);
        anim.SetBool("isHit", false);
    }



}
