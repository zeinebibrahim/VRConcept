using UnityEngine;
using UnityEngine.UI;

public class Endscreen : MonoBehaviour
{
    [SerializeField] Text HighscoreText;
    [SerializeField] Text ScoreText;
    private int highscore;
    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateEndscreenUI()
    {
        HighscoreText.text = "Highscore: " + highscore.ToString();
        ScoreText.text = "Score: " + score.ToString();
    }
}
