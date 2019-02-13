using UnityEngine;
using UnityEngine.UI;

public class CoinsHud : MonoBehaviour
{
    public Text coinsAmount;

    // Update is called once per frame
    void Update()
    {
        coinsAmount.text = PlayerCoins.Coins.ToString();
    }
}
