using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {
    public GameObject continueMenu;
    private Regex blockRegex;
    private Regex coinRegex;
	// Use this for initialization
	void Start () {
        blockRegex = new Regex("block");
        coinRegex = new Regex("coin");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "coin")
        {
            int coins = PlayerPrefs.GetInt("coins", 0);
            PlayerPrefs.SetInt("coins", coins + 1);
            Destroy(collision.gameObject);
            Debug.Log(PlayerPrefs.GetInt("coins", 0));
        } 
        else
        {
            GameManager.state = GameState.GameOver;
            Time.timeScale = 0;
            continueMenu.SetActive(true);
        }*/
       
    }
}
