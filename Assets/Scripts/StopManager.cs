using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopManager : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ball"))
        {
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    float time = 0.01f;
    float eraseTime = 1.0f;
    Rigidbody2D rb;
    CircleCollider2D box2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box2 = GetComponent<CircleCollider2D>();
        box2.enabled = false;
        rb.velocity = new Vector2(speed, 0);
        StartCoroutine(WaitForMove());
    }

    void Update()
    {
        eraseTime -= time;

        if (eraseTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector2.zero;
        box2.enabled = true;
        iTween.ScaleTo(gameObject, new Vector3(0.1f, 0.1f, 1.0f), 0.5f);
    }
}
