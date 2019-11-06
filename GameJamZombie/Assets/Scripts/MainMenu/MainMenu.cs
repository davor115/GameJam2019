using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public GameObject _canvas;

    void Start()
    {
        _canvas = GameObject.Find("LevelChanger");

    }


    public void Start_Game()
    {
        Debug.Log("Click start.");
       // _canvas.GetComponent<FadeScript>().FadeToLevel(1);
        SceneManager.LoadScene(1);
    }

    public void Exit_Game()
    {
        Application.Quit();
    }

    



}
