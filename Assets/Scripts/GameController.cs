using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Text progressText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progressAmount = 0;
        Gem.OnGemCollect += IncreaseProgressAmount;
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        if (progressAmount >= 100)
        {
            // Level complete!
            Debug.Log("Level Complete");
        }

    }

    // Update is called once per frame
    void Update()
    {
        progressText.text = progressAmount.ToString();
    }
}
