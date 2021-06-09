using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    private GameManager manager;

    public TMP_Text scoreText;
    public TMP_Text timer;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    void Update()
    {
        UpdateScore();
        UpdateClock();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + scoreSystem.score.ToString();
    }

    void UpdateClock()
    {
        timer.text = Mathf.RoundToInt(manager.gameTimer).ToString();
    }
}
