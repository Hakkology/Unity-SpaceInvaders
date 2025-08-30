using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Singleton instance
    public static GameState Instance { get; private set; }

    // Reference to the InvaderGrid
    public InvaderGrid invaderGrid;

    // Player stats
    public int PlayerScore { get; private set; }
    public int PlayerHealth { get; private set; }

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    // Game settings
    public int startingHealth = 3;

    void Awake()
    {
        // Ensure singleton instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize player stats
        ResetPlayerStats();
    }

    // Update player score
    public void AddScore(int points)
    {
        PlayerScore += points;
        UpdateScore();
        Debug.Log("Player Score: " + PlayerScore);
    }

    // Update player health
    public void TakeDamage(int damage)
    {
        PlayerHealth -= damage;
        UpdateHealth();
        Debug.Log("Player Health: " + PlayerHealth);

        if (PlayerHealth <= 0)
        {
            HandleGameOver();
        }
    }

    // Reset player stats
    public void ResetPlayerStats()
    {
        PlayerScore = 0;
        PlayerHealth = startingHealth;

        Debug.Log("Game reset. Score: " + PlayerScore + ", Health: " + PlayerHealth);
    }

    // Reset the entire game state
    public void ResetGame()
    {
        ResetPlayerStats();
        invaderGrid.ResetGame(); // Reset InvaderGrid to chapter 1
    }

    // Handle game over logic
    private void HandleGameOver()
    {
        ResetGame();
    }

    public void UpdateHealth()
    {
        healthText.text = "Hp: " + PlayerHealth + "";
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + PlayerScore + "";
    }
}
