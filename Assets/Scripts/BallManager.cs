using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour 
{
    [SerializeField]
    Vector2 velocity = Vector2.zero;
    [SerializeField]
    float time = 0.01f;
    [SerializeField]
    AudioClip[] clips;
    Image timeImage;
    float eraseTime = 1.0f;
    Rigidbody2D rb;

    AudioSource audio;

    void OnCollisionEnter2D(Collision2D collision)
    {
        int num = Random.Range(0, 5);
        audio.PlayOneShot(clips[num]);
    }

    void Start () 
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        timeImage = GetComponentInChildren<Image>();
        rb.AddForce(velocity);
	}

    void Update()
    {
        eraseTime -= time;
        timeImage.fillAmount = eraseTime;

        if(eraseTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
