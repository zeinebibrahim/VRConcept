using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] Text PointsText;
    private int points;
    private int Highscore = 0;




    private void Start()
    {
        UpdatePointUI();
    }

    public void AddPoints(int pPointsToAdd, float pMult)
    {

        if (pMult > 1f)
        {
            points += Mathf.RoundToInt(pPointsToAdd * pMult);
            print($"points added {points}");
        }
        else
        {
            points += Mathf.Abs(pPointsToAdd);
        }
        points += points;
        print("displayed points: " + points);
        points = 0;
        UpdatePointUI();
    }

    void ResetPoints()
    {

        points = 0;
        UpdatePointUI();
    }
    public void GameDone()
    {
        if (points > Highscore)
        {
            Highscore = points;
            print("New Highscore: " + Highscore);
            PlayerPrefs.SetInt("Highscore", Highscore);
        }
        else
        {
            print("Score: " + points + " | Highscore: " + Highscore);
        }
        PlayerPrefs.SetInt("Score", points);
        ResetPoints();
    }

    private void UpdatePointUI()
    {
        PointsText.text = "Points: " + points.ToString();
    }
}
