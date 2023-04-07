using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    float totalTime = 0;
    float passedTime = 0;

    bool working = false;
    bool started = false;

    /// <summary>
    /// Geri Sayým sayacýnýn toplam süresini ayarlar
    /// </summary>
    public float TotalTime
    {
        set
        {
            if (!working)
            {
                totalTime = value;
            }
        }

    }

    /// <summary>
    /// Geri saymýn bitip bitmediðini söyler
    /// </summary>
    public bool Finished
    {
        get
        {
            return started && !working;
        }
    }

    /// <summary>
    /// Sayacý calistirir
    /// </summary>
    public void DoWork()
    {
        if (totalTime > 0) 
        {
            working = true;
            started = true;
            passedTime = 0;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (working)
        {
            passedTime += Time.deltaTime;
            if(passedTime >= totalTime)
            {
                working = false;
            }
        }
    }
}
