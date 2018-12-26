using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    private Rigidbody2D rigidbody2D;
    private Vector3 position;

    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, -2.25f);
    }
	
	// Update is called once per frame
	void Update () {
        position = Camera.main.WorldToViewportPoint(transform.position);
        if (position.y < -0.5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            int coins = PlayerPrefs.GetInt("coins", 0);
            PlayerPrefs.SetInt("coins", coins + 1);
            Debug.Log(collision.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
