using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AccuracyScript : MonoBehaviour
{
    [SerializeField] Text AccuracyText;
    private int totalShots = 0;
    private int successfulHits = 0;
    private float accuracy = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            totalShots = 100;
            successfulHits = 5;
            CalculateAccuracy();
        }
    }
    void CalculateAccuracy()
    {
        accuracy = (totalShots / successfulHits) /* 100f*/;
        print(accuracy + "%");
        SetText();
    }
    void SetText() 
    {
        AccuracyText.text = "Accuracy: " + accuracy.ToString("F2") + "%";
    }
    public void addshots(bool Success)
    {
        if (!Success)
        {
            totalShots++;
        }
        else
        {
            successfulHits++;
            totalShots++;
        }
    }
}
