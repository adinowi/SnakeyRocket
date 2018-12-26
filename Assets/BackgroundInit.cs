using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundInit : MonoBehaviour {
    private Rigidbody2D rigidbody;
    private float heightOfActualBackground;
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0, -2.25f);
        heightOfActualBackground = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float y = transform.position.y + heightOfActualBackground;
        if (y <= -Camera.main.orthographicSize)
        {
            Destroy(this.gameObject);
        }
    }
}
