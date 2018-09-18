using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapScript : MonoBehaviour {

    private ShowerGameScript gm;
    private float speed;

	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<ShowerGameScript>();
        speed = gm.difficulty;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.fixedDeltaTime, 0);
        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gm.cleanliness.value++;
        Destroy(this.gameObject);
    }
}
