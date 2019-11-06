using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour {

    float stepTimer;

    public GameObject _canvas;
    bool isAlive;
    float WaitDeath;
    public Player playerClass;
    PlayerAnimations p_anim;
    Rigidbody p_rigidbody;
    public Collider[] allColliders;
    public LayerMask LayerMask;

    [SerializeField]
    float mov_speed;

    float mov_jumpDistance;
    float mov_weight;

    [SerializeField]
    bool isOnGround;
    public float p_health;
    public int killCount;

    void Awake()
    {
        p_health = playerClass.player_health;
    }


	// Use this for initialization
	void Start ()
    {
        isAlive = true;
        WaitDeath = 4.0f;
        stepTimer = 0.65f;
        _canvas = GameObject.Find("LevelChanger");
        Camera.main.GetComponent<Camera_Follow>().changingScene = true;
        // Get components:
        p_rigidbody = this.gameObject.GetComponent<Rigidbody>();
        p_anim = this.gameObject.GetComponent<PlayerAnimations>();
        // Initialize stats:
        mov_speed = playerClass.player_mov_speed; // make = GetClass().GetSpeed(); Later..
              
        mov_jumpDistance = 2.5f - playerClass.player_weight; // make = GetClass().GetJumpDistance();
        killCount = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Controls();
        PlayerCheckHealth();

    }

    void  Controls()
    {

      //  Debug.Log("Current Rotation: " + transform.rotation.y);
        if (Input.GetKey(KeyCode.A))
        {
            // Move left
            if (!this.GetComponent<AudioSource>().isPlaying && stepTimer <= 0)
            {
                this.GetComponent<AudioSource>().Play();
                stepTimer = 0.65f;
            }
            else
            {
                stepTimer -= Time.deltaTime;
            }
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Hotel" || scene.name == "TrainStation" || scene.name == "trainMoving")
            {
                transform.Translate(-transform.forward * mov_speed * Time.deltaTime);
               
            }            
            else
            {
                transform.Translate(-transform.right * mov_speed * Time.deltaTime);
                
            }
           

          
                if (transform.rotation.y <= 0.5f && transform.rotation.y >= -0.5f)
                {
                 //   Debug.Log("Walking normal");

                    p_anim.WalkBackwards();

                }
                else
                {
                   // Debug.Log("Walking backwards");
                    p_anim.Walking();
                }
            
           
        }
        if(Input.GetKey(KeyCode.D))
        {
            if (!this.GetComponent<AudioSource>().isPlaying && stepTimer <= 0)
            {
                this.GetComponent<AudioSource>().Play();
                stepTimer = 0.65f;
            }
            else
            {
                stepTimer -= Time.deltaTime;
            }
             
            // Move right
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Hotel" || scene.name == "TrainStation" || scene.name == "trainMoving")
            {
                transform.Translate(transform.forward * mov_speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(transform.right * mov_speed * Time.deltaTime);
            }


            if (scene.name == "Field")
            {
                if (transform.rotation.y <= 0.5f && transform.rotation.y >= -0.5f)
                {
                    p_anim.WalkBackwards();

                }
                else
                {

                    p_anim.Walking();

                }
            }
            else
            {
                if (transform.rotation.y <= 0.5f && transform.rotation.y >= -0.5f)
                {
                    p_anim.Walking();
                }
                else
                {

                    p_anim.WalkBackwards();

                }
            }

           
        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            p_anim.Idle();
            this.GetComponent<AudioSource>().Stop();
        }
        //if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isOnGround) // && isOnGround
        //{
        //    // Jump
        //    p_rigidbody.AddForce(Vector3.up * mov_jumpDistance, ForceMode.Impulse);
        //}
        
    }



    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isOnGround = true;
        //    Debug.Log("Collided with the ground");
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isOnGround = false;
         //   Debug.Log("In the AIR!");
        }
       
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "MoveCam") // This will be removed, it just activates camera follow
        {
            Camera.main.GetComponent<Camera_Follow>().changingScene = true;
        }
        else if(other.gameObject.name == "Stop_Camera") // Trigger Box that stops the camera
        {
            Camera.main.GetComponent<Camera_Follow>().changingScene = false;
        }
    }

    public void take_damage(float _dmg)
    {
        p_health -= _dmg;
        p_anim.isHit();
    }

    void PlayerCheckHealth()
    {
        if(p_health <= 0)
        {
            
            p_anim.Die();
            
            if (isAlive && WaitDeath <= 0)
            {
                _canvas.GetComponent<FadeScript>().FadeToLevel(6);
                isAlive = false;
            }
            else
            {
                WaitDeath -= Time.deltaTime;
            }
        }
    }


}
