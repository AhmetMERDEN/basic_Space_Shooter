using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    const float forcePower = 7;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    GameObject explosionPrefab;

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = Camera.main.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0)
        {
            position.x += horizontalInput * forcePower * Time.deltaTime;
        }

        if (verticalInput != 0)
        {
            position.y += verticalInput * forcePower * Time.deltaTime;
        }

        transform.position = position;

        if (Input.GetButtonDown("Jump"))
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>().Fire();
            Vector2 bulletPosition = gameObject.transform.position;
            bulletPosition.y += 1;
            Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid") 
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>().ShipExplosion();
            gameController.FinishGame();
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
