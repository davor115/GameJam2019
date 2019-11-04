using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Player playerClass;

    Rigidbody p_rigidbody;
    public Collider[] allColliders;
    public LayerMask LayerMask;

    [SerializeField]
    float mov_speed;

    float mov_jumpDistance;
    float mov_weight;

    [SerializeField]
    bool isOnGround;
    float p_health;

	// Use this for initialization
	void Start ()
    {

        // Get components:
        p_rigidbody = this.gameObject.GetComponent<Rigidbody>();
        
        // Initialize stats:
        mov_speed = playerClass.player_mov_speed; // make = GetClass().GetSpeed(); Later..
        p_health = playerClass.player_health;        
        mov_jumpDistance = 2.5f - playerClass.player_weight; // make = GetClass().GetJumpDistance();

    }
	
	// Update is called once per frame
	void Update ()
    {
        Controls();        
	}

    void  Controls()
    {
        if(Input.GetKey(KeyCode.A))
        {
            // Move left
            transform.Translate(-Vector3.right * mov_speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            // Move right
            transform.Translate(Vector3.right * mov_speed * Time.deltaTime);
        }
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isOnGround) // && isOnGround
        {
            // Jump
            p_rigidbody.AddForce(Vector3.up * mov_jumpDistance, ForceMode.Impulse);
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isOnGround = true;
            Debug.Log("Collided with the ground");
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isOnGround = false;
            Debug.Log("In the AIR!");
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
