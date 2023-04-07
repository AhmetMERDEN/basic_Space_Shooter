using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    AudioClip asteroidExplosion = default;

    [SerializeField]
    AudioClip shipExplosion = default;

    [SerializeField]
    AudioClip fire = default;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   public void AsteroidExplosion()
    {
        audioSource.PlayOneShot(asteroidExplosion, 0.4f);
    }

    public void ShipExplosion() 
    {
        audioSource.PlayOneShot(shipExplosion, 0.4f);
    }

    public void Fire()
    {
        audioSource.PlayOneShot(fire, 0.2f);
    }
}
