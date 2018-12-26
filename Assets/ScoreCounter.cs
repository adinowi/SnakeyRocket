using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    private Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = GameManager.score.ToString();
	}
}
