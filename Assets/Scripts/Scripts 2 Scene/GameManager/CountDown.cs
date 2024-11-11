using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public float countDown;
    public int seconds;
    GameOn s_managerGameOn;

    public bool timeCountTo0;

    private void Awake()
    {
        s_managerGameOn = GetComponent<GameOn>();   
    }
    private void Start()
    {
        timeCountTo0 = false;
        countDown = 30;
    }

    private void Update()
    {
        if (s_managerGameOn.gameOn == true)
        {
            TimeCounter();
        }
        else
            countDown = 30;
    }

    public void TimeCounter()
    {
        countDown -= Time.deltaTime;

        if(countDown <= 0)
        {
            timeCountTo0 = true;

        }
        seconds = Mathf.FloorToInt(countDown % 60f);
    }

}
