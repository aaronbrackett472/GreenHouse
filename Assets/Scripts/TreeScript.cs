using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {

    public Sprite stage2;
    public Sprite stage3;
    public Sprite stage4;

    private InfoScript info;
    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        info = FindObjectOfType<InfoScript>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (info.completed() >= 9)
        {
            sr.sprite = stage2;
        }
        if (info.completed() >= 18)
        {
            sr.sprite = stage3;
        }
        if (info.completed() >= 27)
        {
            sr.sprite = stage4;
        }
    }
}
