using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    CountDownTimer countDownTimer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        countDownTimer = gameObject.AddComponent<CountDownTimer>();
        countDownTimer.TotalTime = 3;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
        }     
    }
}
