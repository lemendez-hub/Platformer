using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScoreControl : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.collider.CompareTag("Question"))
                {
                    Debug.Log("Coin");
                    CoinTracker.FindAnyObjectByType<CoinTracker>().coinCount++;
                    AddScore(100);
                }
            }
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.collider.CompareTag("Brick"))
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log("Brick Destroyed");
                    AddScore(50);
                }
                if (scoreText != null)
                {
                scoreText.text = "Score\n" + score.ToString("D6");
                }
            }
        }
    }

    void AddScore(int amount)
    {
        score += amount;
    }
}