using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

    public List<Transform> lights;
    public Sprite onSprite;
    public Sprite offSprite;
    public Sprite onSwitch;
    public Sprite offSwitch;
    private bool status;

	// Use this for initialization
	void Start () {
        status = true;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void clicked()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            Transform light = lights[i];
            if (light.tag == "on")
            {
                light.GetComponent<SpriteRenderer>().sprite = offSprite;
                light.tag = "off";
            }
            else
            {
                light.GetComponent<SpriteRenderer>().sprite = onSprite;
                light.tag = "on";
            }
        }

        if (status == true)
        {
            GetComponent<SpriteRenderer>().sprite = offSwitch;
            status = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = onSwitch;
            status = true;
        }
    }
   
}
