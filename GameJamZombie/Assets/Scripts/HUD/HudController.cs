using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HudController : MonoBehaviour {
    public GameObject Player;
    public GameObject Gun;
    public Image health_image;

    public TextMeshProUGUI mag_text;
    public TextMeshProUGUI reserve_text;

    float fillAmount;
	// Use this for initialization
	void Start ()
    {
       // Player = GameObject.FindGameObjectWithTag("Player");
      //  Gun = GameObject.FindGameObjectWithTag("Gun");
    }
	
	// Update is called once per frame
	void Update ()
    {

        //   h_image.fillAmount = Mathf.Lerp(h_image.fillAmount, Player.GetComponent<Movement>().p_health, Time.deltaTime * 2.0f);
        health_image.fillAmount = Player.GetComponent<Movement>().p_health / 100.0f;

        mag_text.SetText(Gun.GetComponent<Gun_Controls>().gun_magazine.ToString());
        reserve_text.SetText(Gun.GetComponent<Gun_Controls>().gun_reserve.ToString());


	}
}
