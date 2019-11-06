using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class EnemyBaseActions : MonoBehaviour {

    GameObject Player;
    public Enemy enemy;
    NavMeshAgent agent;
    EnemyAnimations zombieAnim;
    public bool ImOnScreen;
    bool isAlive;
    float dieWait;

    public float health;
    public float mov_speed;
    float attack_speed;
    float attack_cooldown;
	// Use this for initialization
	void Start ()
    {
        isAlive = true;
        dieWait = 15.0f;
        ImOnScreen = false;
        zombieAnim = gameObject.GetComponent<EnemyAnimations>();
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
        if (Vector3.Distance(Player.transform.position, transform.position) > 1.5f)
        {
            // transform.LookAt(Player.transform);
            // transform.Translate(Vector3.forward * Time.deltaTime * mov_speed);
            zombieAnim.ZombieWalk();
            StartCoroutine(Check());
            agent.SetDestination(Player.transform.position);
           
        }
        else
        {
            if (attack_cooldown <= 0 && isAlive)
            {
                Player.GetComponent<Movement>().take_damage(5.0f);
                Debug.Log("Attacking..");
                zombieAnim.ZombieAttack();
                attack_cooldown = attack_speed;
            }
            agent.ResetPath();
        }
        attack_cooldown -= Time.deltaTime;
    }

    public void TakeDamageZombie(float _dmg)
    {
        health -= _dmg;
       
    }

    void checkHealth()
    {
        if(health <= 0 && isAlive)
        {
            isAlive = false;
            Debug.Log("I died");
            Player.GetComponent<Movement>().killCount += 1;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            this.gameObject.GetComponent<EnemyBaseActions>().enabled = false;
            zombieAnim.ZombieDie();          
            if (dieWait <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                dieWait -= Time.deltaTime;
            }
        }
    }

    IEnumerator Check()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position); // get the position of the zombie and transform it to view port point.
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1; // We check if the zombie is in the screen.
        if (onScreen) // If the zombie is not on the screen..
        {
            ImOnScreen = true;
            //  transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z); // Allocate so it has the same position.
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Field")
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Player.transform.position.z), Time.deltaTime * mov_speed);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.transform.position.x, transform.position.y, transform.position.z), Time.deltaTime * mov_speed);
            }
            

        }
        else
        {
            ImOnScreen = false;
        }
        yield return new WaitForSeconds(5.0f); // Run this Co routine every 5 seconds..
    }


}
