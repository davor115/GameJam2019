using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Controls : MonoBehaviour {

    GameObject Player;
    float currentHitDistance;
    public LayerMask LayerMask;
    // speed is the rate at which the object will rotate
    float speed;

    public Gun pickedGun;

    public GameObject _BulletPrefab;


    [SerializeField]
    float gun_cooldown;
    float gun_fireRate;
    public int gun_magazine;
    public int gun_reserve;
    float gun_damage;
    void Start()
    {
        speed = 10.0f;
        Player = GameObject.FindGameObjectWithTag("Player");
        // If Pistol:
        gun_fireRate = pickedGun.gun_fireRate;
        gun_magazine = pickedGun.gun_magazine;
        gun_reserve = pickedGun.gun_reserve;
        gun_damage = pickedGun.gun_damage;

        gun_cooldown = gun_fireRate;
    }

    void Update()
    {
        PlayerGunControlls();
        // Debug.Log("Magazine: " + gun_magazine);
        //  Debug.Log("Reserve: " + gun_reserve);
        Debug.DrawRay(transform.position, transform.forward * 15.0f);
    }

    //void OnDrawGizmosSelected()
    //{
    //    // Draw a yellow sphere at the transform's position
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, transform.position + transform.forward * currentHitDistance);
    //    Gizmos.DrawWireSphere(transform.position + transform.forward * currentHitDistance, 2.5f);
    //}

    void FixedUpdate()
    {
        GunMovement();
    }

    void GunMovement()
    {
        // Generate a plane that intersects the transform's position with an right normal.
        Plane playerPlane = new Plane(Vector3.right, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Debug.Log("Target Point: " + targetPoint);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            Quaternion targetRotation2 = Quaternion.LookRotation(new Vector3(targetPoint.x, Player.transform.position.y, targetPoint.z) - Player.transform.position);
      
            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, targetRotation2, speed * Time.deltaTime);
        }
    }
    float AngleBetweenPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.x - b.x, a.z - b.z) * Mathf.Rad2Deg;
    }



    void PlayerGunControlls()
    {
        if(Input.GetKey(KeyCode.Mouse0) && gun_cooldown <= 0)
        {
            Shoot();
            gun_cooldown = gun_fireRate;
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        gun_cooldown -= Time.deltaTime;

    }


    void Shoot()
    {
        if (gun_magazine > 0)
        {
            Ray myRay = new Ray(transform.position, transform.forward);

            RaycastHit hit;
            // Physics.SphereCast(transform.position, 2.5f, transform.forward, out hit, 30.0f)
            if (Physics.Raycast(myRay, out hit, 15.0f, LayerMask))
            {
                Debug.Log("We hit: " + hit.collider.name);
                currentHitDistance = hit.distance;
                if (hit.collider.CompareTag("Enemy"))
                {
                   // hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    if(hit.collider.gameObject.GetComponent<EnemyBaseActions>().ImOnScreen)
                    {
                        Instantiate(_BulletPrefab, hit.collider.transform.position, Quaternion.identity);
                        hit.collider.gameObject.GetComponent<EnemyBaseActions>().TakeDamageZombie(gun_damage);
                    }                   
                }
            }

            gun_magazine -= 1;
        }
        else
        {
            Debug.Log("RELOAD!");
        }

    }

    void Reload()
    {
       if(gun_reserve > 0)
        {
            int tmp = pickedGun.gun_magazine - gun_magazine; 
            if(tmp <= gun_reserve)
            {
                gun_reserve -= tmp;
                gun_magazine += tmp;
            }
            else
            {
                int tmp2 = gun_reserve;
                gun_magazine += tmp2;
                gun_reserve -= tmp2;
            }
        }
    }

}
