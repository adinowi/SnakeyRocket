using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockInit : MonoBehaviour {
    private Vector3 position;
    public GameObject Player;
    private bool addedPoint = false;
    private double playerPosition;
    protected Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start () {
        initBlock();
    }

    protected void initBlock()
    {
        playerPosition = Player.transform.position.y - Player.GetComponent<SpriteRenderer>().size.y / 4;
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
        if (playerPosition > gameObject.transform.position.y)
        {
            if (!addedPoint)
            {
                addedPoint = true;
                GameManager.score += GameManager.scoreMultipler * 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == Player.gameObject.name){
            GameManager.state = GameState.GameOver;
            Time.timeScale = 0;
        }

    }
}
