using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BoosterCommand {
    void execute();
}

public class BoosterController : MonoBehaviour {
    private int layerMask = 1 << 8;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                var ray = Camera.main.ScreenPointToRay(touch.position);
                //RaycastHit hit;
                //Debug.Log(Physics2D.Raycast(new Vector2(ray., ray.y), out hit));
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), new Vector2(ray.direction.x, ray.direction.y), Mathf.Infinity, layerMask);
                if (hit.collider != null)
                {
                    BoosterCommand booster = hit.transform.gameObject.GetComponent<BoosterCommand>();
                    booster.execute();
                }
            }
        }
    }
}
