using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private const float deltaError = 0.02f;
    private const int maxDegreeOfRotation = 90;
    public GameObject Player;
    private Vector3 touchOrigin;
    private float rotateSpeed = 20f;
    private float oneQuarterOfWorldWidth;
    private float rotationValue = 0;
    private float actualSign = 1;
    private int fingerId;
    private SpriteRenderer renderer;
    private float halfWidth;

    /*public GameObject block;
    private Vector3 position;*/

    // Use this for initialization
    void Start () {
        halfWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f)).x;
        oneQuarterOfWorldWidth = halfWidth / 2;
        renderer = Player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.state == GameState.Playing)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
                if (Input.touchCount > 1)
                {
                    fingerId = touch.fingerId;
                }
                if (touch.phase == TouchPhase.Began)
                {
                    touchOrigin = Camera.main.ScreenToWorldPoint(touch.position);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Vector3 touchEnd = Camera.main.ScreenToWorldPoint(touch.position);
                    float delta = touchEnd.x - touchOrigin.x;
                    if (Mathf.Abs(delta) > deltaError && fingerId == Input.GetTouch(0).fingerId)
                    {
                        rotationValue = Player.transform.rotation.z + ((delta / oneQuarterOfWorldWidth) * -maxDegreeOfRotation);
                        rotationValue = Mathf.Abs(rotationValue) >= maxDegreeOfRotation ? maxDegreeOfRotation * Mathf.Sign(rotationValue) : rotationValue; // max 90 degrees
                        if (actualSign != Mathf.Sign(delta)) // change direction during movement
                        {
                            Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, Quaternion.Euler(0, 0, (delta / oneQuarterOfWorldWidth) * -90), Time.deltaTime * rotateSpeed);
                            actualSign = Mathf.Sign(delta);
                        }
                        else
                        {
                            Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, Quaternion.Euler(0, 0, rotationValue), Time.deltaTime * rotateSpeed);
                        }
                        Vector3 touchedPos = new Vector3(Player.transform.position.x + delta, Player.transform.position.y, 10);
                        //Debug.Log(Player.transform.position);
                        if (touchedPos.x - renderer.bounds.size.x / 2 > -halfWidth && touchedPos.x + renderer.bounds.size.x / 2 < halfWidth)
                        {
                            // lerp and set the position of the current object to that of the touch, but smoothly over time.
                            Player.transform.position = Vector3.Lerp(Player.transform.position, touchedPos, 1f);
                        }
                    }
                    touchOrigin = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                }
                else
                {
                    Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotateSpeed);
                }
            }
            else
            {
                Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotateSpeed);
            } 
        }
    }
}
