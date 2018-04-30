using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour 
{
    [SerializeField]
    float maxHp = 1.0f;
    float hp;
    Image hpImage;

    public void Delete()
    {
        Destroy(gameObject);
    }

    public void Damage()
    {
        --hp;

        hpImage.fillAmount = hp / maxHp;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        hpImage = GetComponentInChildren<Image>();
        hp = maxHp;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Ball"))
        {
            Damage();
        }
    }
}
