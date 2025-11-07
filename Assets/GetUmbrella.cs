using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioClip))]
[RequireComponent(typeof(BoxCollider2D))]

public class GetUmbrella : MonoBehaviour
{
    [SerializeField] float followForceOveride = 150, rotationSpeedOveride = 5, massOveride = 1;
    AudioSource aS;
    bool hasPlayed;

    // Start is called before the first frame update
    void Start()
    {
        aS = gameObject.GetComponent<AudioSource>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void Update()
    {
        if (aS.isPlaying == false && hasPlayed == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            if (collision.transform.GetChild(1).GetComponent<WeaponSway>() != null)
            {
                aS.Play();
                WeaponSway YES = collision.transform.GetChild(1).GetComponent<WeaponSway>();
                Rigidbody2D YESrb = YES.rb;

                YES.followStrength = followForceOveride;
                YES.rotateSpeed = rotationSpeedOveride;
                YESrb.mass = massOveride;

                hasPlayed = true;

                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
