using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour {
    public GameObject[] Backgrounds;
    private int index;
    private GameObject actualBackground;
    private float heightOfActualBackground;
    // Use this for initialization
    void Start()
    {
        actualBackground = Instantiate(Backgrounds[0], new Vector3(0, -Camera.main.orthographicSize), Quaternion.identity);
        heightOfActualBackground = actualBackground.GetComponent<SpriteRenderer>().bounds.size.y;
        index++;
        //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)));
    }
	
	// Update is called once per frame
	void Update () {
        float y = actualBackground.transform.position.y + heightOfActualBackground;
        if( y <= Camera.main.orthographicSize)
        {
            if(index >= Backgrounds.Length - 0.05)
            {
                index = 0;
            }
            actualBackground = Instantiate(Backgrounds[index], transform.position, Quaternion.identity);
            heightOfActualBackground = actualBackground.GetComponent<SpriteRenderer>().bounds.size.y;
            index++;
            //y = 15;
        }
    }
}
