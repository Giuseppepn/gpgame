using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public static bool timerIsOn = false;
    public static float timer = 0.0f;
    private static TimerScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;  
    }

    void Update()
    {
        if (timerIsOn)
        {
            timer += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        timerIsOn = true;
    }

    public void StopTimer()
    {
        timerIsOn = false;
    }

    public float GetTime()
    {
        return timer;
    }
}
