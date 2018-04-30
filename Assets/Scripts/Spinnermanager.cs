using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spinnermanager : MonoBehaviour 
{
    [SerializeField]
    float rotateSpeed = 5.0f;
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    float time = 0.01f;
    float eraseTime = 1.0f;
    Rigidbody2D rb;
    BoxCollider2D box2;
    bool isSpin = false;

	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        box2 = GetComponent<BoxCollider2D>();
        box2.isTrigger = true;
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
	
    void FixedUpdate()
    {
        if(isSpin)transform.eulerAngles += new Vector3(0, 0, rotateSpeed);
    }

    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector2.zero;
        isSpin = true;
        box2.isTrigger = false;
        iTween.ScaleTo(gameObject, new Vector3(0.2f, 2f, 1.0f), 0.5f);
    }

}
