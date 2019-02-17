using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public static PlayerCoins Instance;

    public static int Coins { get { return Instance.currentCoins; } }

    [SerializeField]
    private int initialCoins = 200;

    [SerializeField]
    private int maxCoins = 99999;

    private int currentCoins;


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        currentCoins = initialCoins;
    }

    public static void AddCoins(int coins)
    {
        Instance.currentCoins += coins;
        if (Instance.currentCoins > Instance.maxCoins)
        {
            Instance.currentCoins = Instance.maxCoins;
        }
    }

    public static void SpendCoins(int coins)
    {
        Instance.currentCoins -= coins;
    }

}
