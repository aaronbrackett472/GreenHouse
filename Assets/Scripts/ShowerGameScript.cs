using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowerGameScript : MonoBehaviour {

    public Transform border;
    public Transform soap;
    public Transform duck;
    public int difficulty;

    private int spawnCounter;
    public int spawnTime;

    private System.Random rand;
    private List<float> positions;


    public Slider water;
    public Slider cleanliness;

    public Text lose;
    public Text win;

    public Button tryAgainButton;

    private InfoScript info;
    public Button nextDiffButton;
    public Button hubButton;

    // Use this for initialization
    void Start () {

        lose.enabled = false;
        win.enabled = false;
        nextDiffButton.gameObject.SetActive(false);
        tryAgainButton.gameObject.SetActive(false);
        hubButton.gameObject.SetActive(false);

        info = GameObject.Find("Game Info").GetComponent<InfoScript>();
        if (info != null)
        {
            difficulty = info.activeDifficulty;
        }

        positions = new List<float>();
		for (float i = -11; i <= 11; i += 22f / difficulty)
        {
            Instantiate(border, new Vector3(i, -6, 0), border.transform.rotation);
            positions.Add(i + 11f / difficulty);
        }
        duck.transform.localScale = new Vector3((1000 / difficulty) / 20, (1000 / difficulty) / 20, 1);
        rand = new System.Random();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (spawnCounter >= spawnTime - (difficulty*2))
        {
            int pos = rand.Next(0, (int) difficulty);
            soap.transform.localScale = new Vector3((1000/difficulty)/20, (1000 / difficulty)/20, 1);
            Instantiate(soap, new Vector3(positions[pos], 5, 0), soap.transform.rotation);
            spawnCounter = 0;
        }
        spawnCounter++;

        if (Input.GetMouseButtonDown(0))
        {
            float duckPosition = 0;
            for (int i = 0; i < difficulty; i++)
            {
                if (i * Screen.width / difficulty < Input.mousePosition.x && Input.mousePosition.x <= (i+1) * Screen.width / difficulty)
                {
                    duckPosition = positions[i];
                    break;
                }
            }
            duck.transform.SetPositionAndRotation(new Vector3(duckPosition, -3, 0), duck.transform.rotation);
            
        }

        water.value -= Time.deltaTime * (difficulty);
        if (water.value <= 0)
        {
            lose.enabled = true;
            tryAgainButton.enabled = true;
            Destroy(this);
        }
        
        if (cleanliness.value >= cleanliness.maxValue)
        {
            win.enabled = true;
            nextDiffButton.enabled = true;
            if (info.activeDifficulty > info.ShowerDiff)
            {
                info.ShowerDiff = info.activeDifficulty;
            }            
            Destroy(this);
        }
	}

}
