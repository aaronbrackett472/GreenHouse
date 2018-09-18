using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {

    private InfoScript info;


    public void Start()
    {
        info = GameObject.Find("Game Info").GetComponent<InfoScript>();
    }

    public void nextDiff()
    {
        info.activeDifficulty += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void backToHub()
    {
        SceneManager.LoadScene(0);
    }

    public void tryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
