using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmutableBooster : MonoBehaviour, BoosterCommand {
    public GameObject player;
    public void execute()
    {
        GetComponent<Animator>().enabled = true;
        player.GetComponent<PolygonCollider2D>().enabled = false;
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
        player.GetComponent<PolygonCollider2D>().enabled = true;
        gameObject.SetActive(false);
        GetComponent<Animator>().enabled = false;
        int quantity = PlayerPrefs.GetInt(ShopSystem.IMMUTABLE_KEY);
        quantity -= 1;
        PlayerPrefs.SetInt(ShopSystem.IMMUTABLE_KEY, quantity);
    }
}
