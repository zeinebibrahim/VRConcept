using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour
{
    private float timeLimit = 60f; // Time limit in seconds


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timeremaining();
    }
    void Timeremaining()
    {
        if (timeLimit <= 0)
        {
            SceneManager.LoadScene("Endscreen");
        }
        else
        {
            timeLimit -= Time.deltaTime;
        }
    }
}
