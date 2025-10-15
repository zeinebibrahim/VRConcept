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
    /// <summary>
    /// Adds points to the current total, applying a multiplier if specified.
    /// </summary>
    /// <remarks>This method updates the total points and refreshes the user interface to reflect the new total. If
    /// the multiplier is greater than <see langword="1.0"/>, the points added are rounded to the nearest integer.</remarks>
    /// <param name="pPointsToAdd">The base number of points to add. Must be a non-negative integer.</param>
    /// <param name="pMult">The multiplier to apply to the points being added. If greater than <see langword="1.0"/>, the base points are
    /// multiplied by this value before being added. If less than or equal to <see langword="1.0"/>, the base points are
    /// added without modification.</param>
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
        UpdatePointUI();
    }
    /// <summary>
    /// this resets the points to 0
    /// </summary>
    void ResetPoints()
    {
        points = 0;
        UpdatePointUI();
    }
    /// <summary>
    /// Finalizes the game session, updates the high score if applicable, and resets the current score.
    /// </summary>
    /// <remarks>If the current score exceeds the high score, the high score is updated and saved.  The
    /// current score is always saved, and the score is reset at the end of the method.</remarks>
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
