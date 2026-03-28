using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;

    public GameObject player;
    public GameObject LoadCanvas;
    public List<GameObject> levels;
    private int currentLevelIndex = 0;

    public GameObject gameOverScreen;
    public TMP_Text survivedText;
    private int survivedLevelsCount;

    public static event Action OnReset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Gem.OnGemCollect += IncreaseProgressAmount;
        HoldToLoadLevel.OnHoldComplete += LoadNextLevel;
        PLayerHealth.OnPlayerDied += GameOverScreen;
        LoadCanvas.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
        survivedText.text = "YOU SURVIVED " + survivedLevelsCount + " LEVEL";
        Debug.Log("Game Over");
        if(survivedLevelsCount != 1) survivedText.text += "S";
        Time.timeScale = 0f; // Pause the game
    }

    public void ResetGame()
    {
        gameOverScreen.SetActive(false);
        survivedLevelsCount = 0;
        LoadLevel(0, false);
        OnReset.Invoke();
        Time.timeScale = 1f; // Resume the game
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;
        if (progressAmount >= 100)
        {
            // Level complete!
            LoadCanvas.SetActive(true);
            Debug.Log("Level Complete");
        }

    }

    void LoadLevel(int level, bool wantSurvivedIncrease)
    {
        LoadCanvas.SetActive(false);

        levels[currentLevelIndex].gameObject.SetActive(false);
        levels[level].gameObject.SetActive(true);

        player.transform.position = new Vector3(0, 0, 0); // Reset player position to the start of the level

        currentLevelIndex = level;
        progressAmount = 0; // Reset progress for the new level
        progressSlider.value = 0;
        survivedLevelsCount++;
        if (wantSurvivedIncrease) survivedLevelsCount++;
    }

    void LoadNextLevel()
    {
        Debug.Log("Loading next level...");
        // Here you would add your code to load the next level, e.g. using SceneManager.LoadScene
        int nextLevelIndex = (currentLevelIndex == levels.Count - 1)? 0 : currentLevelIndex + 1;
        LoadLevel(nextLevelIndex, true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
