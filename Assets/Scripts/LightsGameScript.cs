using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightsGameScript : MonoBehaviour {

    private int difficulty;
    public Transform lightbulb;
    public Transform onSwitch;
    public Text goodjob;
    private List<Transform> lights;
    private InfoScript info;
    public Button nextDiffButton;
    public GameObject buttons; 

    // Use this for initialization
    void Start () {
        goodjob.enabled = false;
        buttons.SetActive(false);
        info = GameObject.Find("Game Info").GetComponent<InfoScript>();
        difficulty = info.activeDifficulty;

        lights = new List<Transform>();

        int numLights = Random.Range(1, difficulty);

        for (int i = 0; i< numLights; i++)
        {
            Transform newLight = Instantiate(lightbulb, new Vector3(-7.5f+i*20/numLights, 2, 0), lightbulb.transform.rotation);
            lights.Add(newLight);
        }

        int numSwitches = Random.Range(numLights, numLights + difficulty);
        Dictionary<int, List<Transform>> switches = new Dictionary<int, List<Transform >>();
        List<int> solution = new List<int>();

        for (int i = 0; i < numSwitches; i++)
        {
            switches[i] = new List<Transform>();
            if (Random.value < .5)
            {
                solution.Add(i);
            }
            else
            {
                for (int j = 0; j < numLights; j++)
                {
                    if (Random.value < .5)
                    {
                        switches[i].Add(lights[j]);
                    }
                }
            }
        }

        for (int i = 0; i < numLights; i++)
        { 
            int numAffected = Random.Range(2, solution.Count * 2);
            numAffected = numAffected/2;
            Debug.Log(numLights);
            Debug.Log(numAffected);
            List<int> choices = new List<int>(solution);
            for (int j = 0; j < numAffected; j++)
            {
                int randIndex = Random.Range(0, choices.Count - 1);
                Debug.Log(randIndex);
                int choice = choices[randIndex];
                switches[choice].Add(lights[i]);
                choices.Remove(choice);
            }
        }

        for (int i = 0; i < numSwitches; i++)
        {
            Transform newSwitch = Instantiate(onSwitch, new Vector3(-7.5f + i * 20 / numSwitches, -2.5f, 0), onSwitch.transform.rotation);
            newSwitch.GetComponent<SwitchScript>().lights = switches[i];
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "switch")
                {
                    Debug.Log("hitswitch");
                    hit.transform.gameObject.GetComponent<SwitchScript>().clicked();
                    bool allOff = true;
                    for (int i = 0; i < lights.Count; i++)
                    {
                        if (lights[i].tag == "on")
                        {
                            allOff = false;
                            break;
                        }
                    }
                    if (allOff == true)
                    {
                        goodjob.enabled = true;
                        if (info.activeDifficulty >= 10)
                        {
                            nextDiffButton.enabled = false;
                        }
                        buttons.SetActive(true);
                        Destroy(this);
                    }
                }
            }
        }
    }
    
}
