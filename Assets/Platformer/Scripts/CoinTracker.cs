using TMPro;
using UnityEngine;

public class CoinTracker : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public int coinCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = $"x{coinCount.ToString("D2")}";
    }
}
