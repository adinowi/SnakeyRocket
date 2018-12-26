using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullBlockController : MonoBehaviour {
    private Rigidbody2D rigidbody2D;
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, -2.25f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
