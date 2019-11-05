using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour {

    Animator anim;


	// Use this for initialization
	void Start ()
    {
        anim = this.gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ZombieAttack()
    {
        anim.SetBool("ZombieAttack", true);
    }

    public void ZombieWalk()
    {
        anim.SetBool("ZombieAttack", false);
        anim.SetBool("ZombieWalk", true);
    }

    public void ZombieDie()
    {
        anim.SetBool("ZombieDeath", true);
        anim.SetBool("ZombieAttack", false);
        anim.SetBool("ZombieWalk", false);
    }


}
