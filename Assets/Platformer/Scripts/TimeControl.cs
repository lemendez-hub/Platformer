using TMPro;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public TextMeshProUGUI timetext;
    float timeLeft = 500;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timetext.text = $"Time\n {((int)timeLeft).ToString()}";
    }
}
