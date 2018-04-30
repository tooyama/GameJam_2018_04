using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreBlockManager : MonoBehaviour 
{
    [SerializeField]
    float rotateSpeed = 1.0f;
    [SerializeField]
    float maxHp = 1.0f;
    [SerializeField]
    Text text;
    float hp;
    Image hpImage;

    GameManager gameManager;
    FieldManager fieldManager;
    EffectManager effectManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Ball"))
        {
            if(hp>0)--hp;

            hpImage.fillAmount = hp / maxHp;

            if (hp <= 0 && !gameManager.GetEnd())
            {
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
                fieldManager.DeleteAll();
                effectManager.transform.parent = null;
                effectManager.SetEffect();
                text.enabled = true;
                gameManager.SetEnd();
                Destroy(gameObject);
            }
        }
    }

	void Start () 
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        text.enabled = false;
        hpImage = GetComponentInChildren<Image>();
        hp = maxHp;
        fieldManager = GetComponentInParent<FieldManager>();
        effectManager = GetComponentInChildren<EffectManager>();
	}

	void FixedUpdate () 
    {
        transform.eulerAngles += new Vector3(0, 0, rotateSpeed);
	}
}
