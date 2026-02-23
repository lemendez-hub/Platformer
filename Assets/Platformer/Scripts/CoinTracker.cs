using TMPro;
using UnityEngine;

public class CoinTracker : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Displays the number of coins collected
    public int coinCount = 0; // Tracks the number of coins collected

    // Update is called once per frame
    void Update()
    {
        coinText.text = $"x{coinCount.ToString("D2")}"; // Update the coin text to show the current coin count, formatted with leading zeros
    }
}