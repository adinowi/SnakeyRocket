using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour {
    public Text CoinsText;
    public Text ImmutablePrice;
    public Text SlowmoPrice;
    public Text DoublePointsPrice;
    public Text ImmutableQuantity;
    public Text SlowmoQuantity;
    public Text DoublePointsQuantity;

    public const int IMMUTABLE_PRICE = 7;
    public const int SLOWMO_PRICE = 4;
    public const int DOUBLE_POINTS_PRICE = 4;

    public const string IMMUTABLE_KEY= "immutableBooster";
    public const string SLOWMO_KEY = "slowmoBooster";
    public const string DOUBLE_POINTS_KEY = "doublePointsBooster";
    public const string COINS_KEY = "coins";

    // Use this for initialization
    void Start () {

		if(!PlayerPrefs.HasKey(COINS_KEY))
        {
            PlayerPrefs.SetInt(COINS_KEY, 0);
        }
        int coinsValue = PlayerPrefs.GetInt(COINS_KEY);
        CoinsText.text = coinsValue.ToString();

        ImmutablePrice.text = IMMUTABLE_PRICE.ToString();
        SlowmoPrice.text = SLOWMO_PRICE.ToString();
        DoublePointsPrice.text = DOUBLE_POINTS_PRICE.ToString();

        ImmutableQuantity.text = PlayerPrefs.GetInt(IMMUTABLE_KEY).ToString();
        SlowmoQuantity.text = PlayerPrefs.GetInt(SLOWMO_KEY).ToString();
        DoublePointsQuantity.text = PlayerPrefs.GetInt(DOUBLE_POINTS_KEY).ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void buyProduct(string key, int price, Text quantityText)
    {
        
        if(PlayerPrefs.HasKey(COINS_KEY))
        {
            int coinsValue = PlayerPrefs.GetInt(COINS_KEY);
            if (coinsValue >= price) {
                if (!PlayerPrefs.HasKey(key))
                {
                    PlayerPrefs.SetInt(key, 0);
                }
                int productQuantity = PlayerPrefs.GetInt(key);
                productQuantity += 1;
                coinsValue -= price;
                PlayerPrefs.SetInt(key, productQuantity);
                PlayerPrefs.SetInt(COINS_KEY, coinsValue);
                quantityText.text = productQuantity.ToString();
            }
        }
        
    }

    public void buyImmutbaleBooster()
    {
        buyProduct(IMMUTABLE_KEY, IMMUTABLE_PRICE, ImmutableQuantity);
    }

    public void buySlowmoBooster()
    {
        buyProduct(SLOWMO_KEY, SLOWMO_PRICE, SlowmoQuantity);
    }

    public void buyDoublePoints()
    {
        buyProduct(DOUBLE_POINTS_KEY, DOUBLE_POINTS_PRICE, DoublePointsQuantity);
    }

}
