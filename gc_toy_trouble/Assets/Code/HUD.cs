using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    private GameManager manager;

    public TMP_Text scoreText;
    public TMP_Text timer;
    public TMP_Text gameStatus;
    public Image blackScreen;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
        blackScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        UpdateScore();
        UpdateClock();
        UpdateGameStatus();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + scoreSystem.score.ToString();
    }

    void UpdateClock()
    {
        timer.text = Mathf.RoundToInt(manager.gameTimer).ToString();
    }

    void UpdateGameStatus()
    {
        if (manager.isMimicAlive)
            gameStatus.text = "Find and destroy the mimic or else...";
        else if (!manager.isMimicAlive)
            gameStatus.text = "Mimic destroyed. Press R to restart or ESC to quit";

        if (manager.isPlayerDead && manager.isMimicAlive)
        {
            gameStatus.text = "You didn't find the mimic in time... Press R to restart or ESC to quit";
            blackScreen.gameObject.SetActive(true);
        }

    }
}
