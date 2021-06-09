using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private ScoreSystem scoreSystem;

    public TMP_Text scoreText;
    public TMP_Text timer;

    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    void Update()
    {
        UpdateScore();   
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + scoreSystem.score.ToString();
    }
}
