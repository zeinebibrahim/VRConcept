using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    [SerializeField] Text TimeText;
    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            startGame();
        }
    }
    public void startGame()
    {
        AddTime();
    }
    void AddTime()
    {
        time += Time.deltaTime;
        SetText();
    }
    void SetText()
    {
        TimeText.text = "Time: " + Time.time.ToString("F2");
    }
}
