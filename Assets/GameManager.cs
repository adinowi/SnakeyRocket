using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    NewGame,
    Playing, 
    GameOver
}

public class GameManager : MonoBehaviour {
    public static GameState state;
    public static GameManager Instance;
    public GameObject continueMenu;
    public GameObject player;
    public GameObject StartMenu;
    public static int score;
    public static int scoreMultipler;
    public GameObject ShopMenu;
    public GameObject CoinsMenu;
    public GameObject ImmutableBooster;
    public GameObject SlowmoBooster;
    public GameObject DoublePointsBooster;
    public Button ContinueButton;
    private bool nextLife;

    // Use this for initialization
    void Start () {
        state = GameState.NewGame;
        Time.timeScale = 0;
        Instance = this;
        Physics2D.IgnoreLayerCollision(8, 9); // ignore collsions between boosters and blocks
        score = 0;
        scoreMultipler = 1;
        nextLife = true;
        intializeShopValues();
        initBoosters();

    }
	
	// Update is called once per frame
	void Update () {
        if(state == GameState.GameOver)
        {
            if(!continueMenu.active)
            {
                continueMenu.SetActive(true);
                if (nextLife)
                {
                    ContinueButton.gameObject.SetActive(true);
                }
                else
                {
                    ContinueButton.gameObject.SetActive(false);
                }
            }
        }
	}

    public void continueGame()
    {
        continueMenu.SetActive(false);
        nextLife = false;
        player.GetComponent<PolygonCollider2D>().enabled = false;
        state = GameState.Playing;
        Time.timeScale = 1;
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        StartCoroutine("waitFiveSeconds");
        
        //player.GetComponent<PolygonCollider2D>().enabled = true;
    }

    private IEnumerator waitFiveSeconds()
    {
        yield return new WaitForSecondsRealtime(5f);
        player.GetComponent<PolygonCollider2D>().enabled = true;
    }

    public void startGame()
    {
        state = GameState.Playing;
        Time.timeScale = 1;
        StartMenu.SetActive(false);
    }

    public void openShop()
    {
        ShopMenu.SetActive(true);
    }

    public void closeShop()
    {
        ShopMenu.SetActive(false);
    }

    public void openCoinsShop()
    {
        CoinsMenu.SetActive(true);
    }

    public void closeCoinsShop()
    {
        CoinsMenu.SetActive(false);
    }

    private void intializeShopValues()
    {
        if(!PlayerPrefs.HasKey(ShopSystem.DOUBLE_POINTS_KEY))
        {
            PlayerPrefs.SetInt(ShopSystem.DOUBLE_POINTS_KEY, 0);
        }
        if (!PlayerPrefs.HasKey(ShopSystem.IMMUTABLE_KEY))
        {
            PlayerPrefs.SetInt(ShopSystem.IMMUTABLE_KEY, 0);
        }
        if (!PlayerPrefs.HasKey(ShopSystem.SLOWMO_KEY))
        {
            PlayerPrefs.SetInt(ShopSystem.SLOWMO_KEY, 0);
        }
        if (!PlayerPrefs.HasKey(ShopSystem.COINS_KEY))
        {
            PlayerPrefs.SetInt(ShopSystem.COINS_KEY, 0);
        }
    }

    private void initBoosters()
    {
        if(PlayerPrefs.GetInt(ShopSystem.IMMUTABLE_KEY) > 0)
        {
            ImmutableBooster.SetActive(true);
        }
        if (PlayerPrefs.GetInt(ShopSystem.SLOWMO_KEY) > 0)
        {
            SlowmoBooster.SetActive(true);
        }
        if (PlayerPrefs.GetInt(ShopSystem.DOUBLE_POINTS_KEY) > 0)
        {
            DoublePointsBooster.SetActive(true);
        }
    }

    public void restartGame()
    {
        Vector3 actualPosition = player.transform.position;
        player.transform.SetPositionAndRotation(new Vector3(0f, actualPosition.y, actualPosition.z), Quaternion.Euler(0, 0, 0));
        (player.GetComponent<Rigidbody2D>()).velocity = new Vector2(0f, 0f);
        GameObject[] objects = GameObject.FindGameObjectsWithTag("block");
        foreach(GameObject obj in objects)
        {
            Destroy(obj);
        }
        state = GameState.Playing;
        continueMenu.SetActive(false);
        initBoosters();
        score = 0;
        Time.timeScale = 1;
    }

    public void backToMenu()
    {
        restartGame();
        Time.timeScale = 0;
        StartMenu.SetActive(true);
    }
}
