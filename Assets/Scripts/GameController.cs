using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    GameObject spaceShipPrefab;

    [SerializeField]
    List<GameObject> asteroidPrefabs = new List<GameObject>();

    GameObject spaceShip;

    List<GameObject> asteroidList = new List<GameObject>();

    [SerializeField]
    int difficulty = 1;
    [SerializeField]
    int multiply = 3;

    UIControl uIControl;

    // Start is called before the first frame update
    void Start()
    {
        uIControl = GetComponent<UIControl>();
    }

    public void StartGame()
    {
        uIControl.GameStarted();
        spaceShip = Instantiate(spaceShipPrefab);
        spaceShip.transform.position = new Vector3(0, ScreenCalculator.Below + 1.5f);
        CreateAsteroid(5);
    }
    

    void CreateAsteroid(int piece)
    {
        Vector3 position = new Vector3();

        for (int i = 0; i < piece; i++) 
        {
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);
            position.x = Random.Range(ScreenCalculator.Left - 0.5f, ScreenCalculator.Right - 0.5f);
            position.y = ScreenCalculator.Above - 1;

            GameObject asteroids = Instantiate(asteroidPrefabs[Random.Range(0,3)], position, Quaternion.identity);
            asteroidList.Add(asteroids);
        }
    }

    public void AsteroidDestroyed(GameObject asteroid)
    {
        uIControl.AsteroidDestroyed(asteroid);
        asteroidList.Remove(asteroid);
        if (asteroidList.Count == difficulty)
        {
            difficulty++;
            CreateAsteroid(difficulty * multiply);
        }
    }

    public void FinishGame()
    {
        foreach (GameObject asteroid in asteroidList)
        {
            asteroid.GetComponent<Asteroid>().DestroyAsteroid();
        }
        asteroidList.Clear();
        difficulty = 1;
        uIControl.GameFinished();
    }
}
