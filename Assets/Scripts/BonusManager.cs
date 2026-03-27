using UnityEngine;
using UnityEngine.UI;
public class BonusManager : MonoBehaviour
{
    public int bonusCount;
    public Text bonusText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bonusText.text = ": " + bonusCount.ToString();
    }
}
