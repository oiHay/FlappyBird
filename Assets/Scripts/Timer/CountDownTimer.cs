using TMPro;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    public float timeRemaining;
    public TextMeshProUGUI timerText;
    public GameObject Counter;

    [HideInInspector] public static bool movementLocked = true;

    private bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 1)
            {
                Counter.SetActive(true);
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                movementLocked = true;
            }
            else
            {
                timeRemaining = 1;
                timerIsRunning = false;
                DisplayTime(timeRemaining);
                Counter.SetActive(false);
                movementLocked = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 1)
        {
            timeToDisplay = 1;
        }

        float seconds = Mathf.FloorToInt(timeToDisplay);
        timerText.text = seconds.ToString();
    }
}
