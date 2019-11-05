using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour {

    public Animator animator;
    private int LevelToLoad;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }
    public void FadeToLevel(int levelIndex)
    {
        LevelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");

    }

    public void onFadeComplete()

    {
        SceneManager.LoadScene(LevelToLoad);


    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
