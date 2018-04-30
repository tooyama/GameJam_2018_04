using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour 
{
    SpriteRenderer sprite;

    public void SetEffect()
    {
        iTween.ScaleTo(gameObject, new Vector3(5.0f, 5.0f, 1.0f), 2.0f);
        iTween.ValueTo(gameObject, iTween.Hash("from", 1.0f, "to", 0f, "time", 2.0f, "onupdate", "SetValue"));
    }

	void Start () 
    {
        sprite = GetComponent<SpriteRenderer>();
	}

    void SetValue(float alpha)
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
    }
}
