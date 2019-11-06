using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalDestroyer : MonoBehaviour {

	public float lifeTime = 1.0f;

	//private IEnumerator Start()
	//{
	//	yield return new WaitForSeconds(lifeTime);
	//	Destroy(gameObject);
	//}

    void Start()
    {
        lifeTime = 1.0f;
    }

    void Update()
    {
       if(lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
       else
        {
            lifeTime -= Time.deltaTime;
        }
    }

}
