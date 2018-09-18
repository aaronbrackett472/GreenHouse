using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HubScript : MonoBehaviour {

    public Canvas startScreen;
    public InfoScript info;
    public Text gameName;
    public Text gameDescription;
    public Button start;
    public Button back;
    public Slider difficulty;

    // Use this for initialization
    void Start () {
        startScreen.enabled = false;
        back.onClick.AddListener(delegate { startScreen.enabled = false; });
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "fridge")
                {
                    displayStart(0);
                }
                if (hit.transform.name == "upstairs")
                {
                    displayStart(1);
                }
                if (hit.transform.name == "lamp")
                {
                    displayStart(2);
                }
            }
        }
    }

    private void displayStart(int game)
    {
        gameName.text = info.gameNames[game];
        gameDescription.text = info.descriptions[game];
        start.onClick.AddListener(delegate { startGame(game + 1); });
        startScreen.enabled = true;
    }

    private void startGame(int sceneIndex)
    {
        info.activeDifficulty = (int) difficulty.value;
        SceneManager.LoadScene(sceneIndex);
    }
}
