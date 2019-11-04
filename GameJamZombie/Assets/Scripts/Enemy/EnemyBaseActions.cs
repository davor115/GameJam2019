using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBaseActions : MonoBehaviour {

    GameObject Player;
    public Enemy enemy;
    NavMeshAgent agent;

    public float health;
    public float mov_speed;
    float attack_speed;
    float attack_cooldown;
	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        health = enemy.enemy_health;
        mov_speed = enemy.enemy_mov_speed;
        attack_speed = enemy.enemy_attack_speed;
        attack_cooldown = attack_speed;
        agent = this.gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If not attacking, walk..
        // Dectect player inmediatly and walk towards him.. no idle animation
        Walk();
        checkHealth();

    }

    void Walk()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) > 2.0f)
        {
            // transform.LookAt(Player.transform);
            // transform.Translate(Vector3.forward * Time.deltaTime * mov_speed);
            agent.SetDestination(Player.transform.position);
           
        }
        else
        {
            if (attack_cooldown <= 0)
            {
                Player.GetComponent<Movement>().take_damage(15.0f);
                attack_cooldown = attack_speed;
            }
            agent.isStopped = true;
        }
        attack_cooldown -= Time.deltaTime;
    }

    public void TakeDamage(float _dmg)
    {
        health -= _dmg;
    }

    void checkHealth()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
