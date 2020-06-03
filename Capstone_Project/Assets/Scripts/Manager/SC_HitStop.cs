﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_HitStop : MonoBehaviour
{
    private float speed;
    private bool restoreTime;

    private void Start()
    {
        restoreTime = false;
    }

    private void Update()
    {
        if (restoreTime)
        {
            if(Time.timeScale < 1f)
            {
                Time.timeScale += Time.deltaTime * speed;
            }
            else
            {
                Time.timeScale = 1f;
                restoreTime = false;
            }
        }
    }

    public void StopTime(float changeTime, int restoreSpeed, float delay)
    {
        speed = restoreSpeed;

        if (delay > 0)
        {
            StopCoroutine(StartTimeAgain(delay));
            StartCoroutine(StartTimeAgain(delay));
        }
        else
        {
            restoreTime = true;
        }

        Time.timeScale = changeTime;
    }

    IEnumerator StartTimeAgain(float amt)
    {
        restoreTime = true;
        yield return new WaitForSecondsRealtime(amt);
    }
}
