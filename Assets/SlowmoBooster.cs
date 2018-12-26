using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowmoBooster : MonoBehaviour, BoosterCommand {
    private Animator animator;
    private Sprite firstSprite;

    public void execute()
    {
        animator.enabled = true;
        Time.timeScale = 0.5f;
        StartCoroutine("waitFiveSeconds");
    }

    // Use this for initialization
    void Start ()
    {
        firstSprite = GetComponent<SpriteRenderer>().sprite;
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.state == GameState.GameOver && animator.enabled == true)
        {
            gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = firstSprite;
            animator.enabled = false;
        }

    }

    private IEnumerator waitFiveSeconds()
    {
        yield return new WaitForSecondsRealtime(5f);
        if (GameManager.state != GameState.GameOver)
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
        GetComponent<SpriteRenderer>().sprite = firstSprite;
        animator.enabled = false;
        int quantity = PlayerPrefs.GetInt(ShopSystem.SLOWMO_KEY);
        quantity -= 1;
        PlayerPrefs.SetInt(ShopSystem.SLOWMO_KEY, quantity);
    }
}
