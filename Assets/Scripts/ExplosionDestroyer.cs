using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyer : MonoBehaviour
{

    CountDownTimer countDownTimer;

   

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = gameObject.AddComponent<CountDownTimer>();
        countDownTimer.TotalTime = 1;
        countDownTimer.DoWork();
    }

    // Update is called once per frame
    void Update()
    {
        if (countDownTimer.Finished)
        {
           
            Destroy(gameObject);

        }
    }
}
