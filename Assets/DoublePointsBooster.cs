using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePointsBooster : MonoBehaviour, BoosterCommand {
    public void execute()
    {
        GetComponent<Animator>().enabled = true;
        GameManager.scoreMultipler = 2;
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
        GameManager.scoreMultipler = 1;
        gameObject.SetActive(false);
        GetComponent<Animator>().enabled = false;
        int quantity = PlayerPrefs.GetInt(ShopSystem.DOUBLE_POINTS_KEY);
        quantity -= 1;
        PlayerPrefs.SetInt(ShopSystem.DOUBLE_POINTS_KEY, quantity);
    }
}
