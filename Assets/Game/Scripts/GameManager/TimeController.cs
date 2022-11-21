using UnityEngine;
using Random = System.Random;

public class TimeController : MonoBehaviour
{
    public int minTime = 15;
    public int maxTime = 25;

    public float timerValue
    {
        get => timer;
    }

    private float timer;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        Random rand = new Random();
        timer = rand.Next(minTime, maxTime + 1);
    }

    public void ResetTimer()
    {
        timer = 0;
    }
}
