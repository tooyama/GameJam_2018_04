using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughBallManager : MonoBehaviour 
{
    [SerializeField]
    Color color;

    void Start()
    {
        StartCoroutine(WaitForChange());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Block"))
        {
            collision.GetComponent<BlockManager>().Delete();
        }
    }

    IEnumerator WaitForChange()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<CircleCollider2D>().isTrigger = false;
        GetComponent<SpriteRenderer>().color = color;
    }
}
