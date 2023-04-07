using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab = default;

    
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        gameController = Camera.main.GetComponent<GameController>();
        
        float direction = Random.Range(0.0f, 1.0f);
        if (direction < 0.5f)
        {
            rb2d.AddForce(new Vector2(Random.Range(-2.5f,-1.0f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
            rb2d.AddTorque(direction * 15.0f);
        }
        else
        {
            rb2d.AddForce(new Vector2(Random.Range(1.0f, 2.5f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
            rb2d.AddTorque(direction * -15.0f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>().AsteroidExplosion();
            gameController.AsteroidDestroyed(gameObject);
            DestroyAsteroid();
        }
    }

    public void DestroyAsteroid()
    {
        Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
