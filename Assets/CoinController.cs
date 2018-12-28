using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinController : MonoBehaviour {
    private Rigidbody2D rigidbody2D;
    private Vector3 position;
    AudioSource audioSource;


    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, -2.25f);
        audioSource = GetComponent<AudioSource>();
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
            int coins = PlayerPrefs.GetInt(ShopSystem.COINS_KEY, 0);
            PlayerPrefs.SetInt(ShopSystem.COINS_KEY, coins + 1);
            Debug.Log(collision.gameObject.name);
            audioSource.Play();
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            StartCoroutine("waitTwoSeconds");
        }
    }

    private IEnumerator waitTwoSeconds()
    {
        yield return new WaitForSecondsRealtime(2f);
        Destroy(this.gameObject);
    }
}
