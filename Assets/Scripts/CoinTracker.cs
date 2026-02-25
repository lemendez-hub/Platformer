using TMPro;
using UnityEngine;

public class CoinTracker : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Reference to element that displays the coin count
    public int coinCount = 0; // To store current number of coins collected
    
    void Update()
    {
        coinText.text = $"x{coinCount.ToString("D2")}"; // To update the UI text and formating the count count
    }
}