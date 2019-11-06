using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour {

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
	// Use this for initialization
	void Start ()
    {
        Camera.main.GetComponent<Camera_Follow>().changingScene = true;
        // Get components:
        p_rigidbody = this.gameObject.GetComponent<Rigidbody>();
        p_anim = this.gameObject.GetComponent<PlayerAnimations>();
        // Initialize stats:
        mov_speed = playerClass.player_mov_speed; // make = GetClass().GetSpeed(); Later..
        p_health = playerClass.player_health;        
        mov_jumpDistance = 2.5f - playerClass.player_weight; // make = GetClass().GetJumpDistance();
        killCount = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Controls();

	}

    void  Controls()
    {

      //  Debug.Log("Current Rotation: " + transform.rotation.y);
        if (Input.GetKey(KeyCode.A))
        {
            // Move left
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
    }


}
