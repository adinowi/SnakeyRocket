using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowmoBooster : MonoBehaviour, BoosterCommand {
    public void execute()
    {
        GetComponent<Animator>().enabled = true;
        Time.timeScale = 0.5f;
        StartCoroutine("waitFiveSeconds");
    }

    // Use this for initialization
    void Start () {
        GetComponent<Animator>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator waitFiveSeconds()
    {
        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        GetComponent<Animator>().enabled = false;
        int quantity = PlayerPrefs.GetInt(ShopSystem.SLOWMO_KEY);
        quantity -= 1;
        PlayerPrefs.SetInt(ShopSystem.SLOWMO_KEY, quantity);
    }
}
