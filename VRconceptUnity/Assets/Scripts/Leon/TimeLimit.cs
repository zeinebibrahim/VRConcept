using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour
{
    private float timeLimit; // Time limit


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timeremaining();
    }
    public void SetTime(int Time)
    {
        timeLimit = Time;
    }
    void Timeremaining()
    {
        if (timeLimit <= 0)
        {
            SceneManager.LoadScene("End Screen");
        }
        else
        {
            timeLimit -= Time.deltaTime;
            Debug.Log(timeLimit);
        }
    }
}
