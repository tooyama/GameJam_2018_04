using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
    [SerializeField]
    float speed = 1.0f;
    float score = 0;
    [SerializeField]
    int num = 0;
    GameObject item;
    Image scoreImage;
    GameManager gameManager;
    bool isRotate = false;

    public float GetScore() { return score; }

    public void RotateAngle(int _num)
    {
        if (isRotate) return;

        isRotate = true;

        StartCoroutine(WaitForRotate());

        num += _num;
        if(2<num)
        {
            num = 0;
        }
        else if(num < 0)
        {
            num = 2;
        }

        if (_num < 0)
        {
            iTween.RotateAdd(item, new Vector3(0f, 0f, -120.0f * speed), 0.5f);
        }
        else
        {
            iTween.RotateAdd(item, new Vector3(0f, 0f, 120.0f * speed), 0.5f);
        }
    }

    public int SetFire(int stageId)
    {
        if(0.9f <= score)
        {
            SetScore(score - 0.9f);
            return 2;
        }
        
        else if (0.6f <= score)
        {
            SetScore(score - 0.6f);
            if(stageId == 0) return 1;
            if (stageId == 1) return 3;
            if (stageId == 2) return 4;
        }
        
        else if (0.2f <= score)
        {
            SetScore(score - 0.2f);
            return 0;
        }

        return -1;
    }

    public void SetScore(float _score)
    {
        score = _score;

        scoreImage.fillAmount = score;

        if (score < 0.2f)
        {
            scoreImage.color = new Color(0f, 0f, 0f, 0.75f);
        }
        else if (score < 0.6f)
        {
            scoreImage.color = new Color(1.0f, 0f, 0f, 0.75f);
        }
        else if (score < 0.9f)
        {
            scoreImage.color = new Color(0f, 0f, 1.0f, 0.75f);
        }
        else
        {
            scoreImage.color = new Color(0f, 1.0f, 0f, 0.75f);
        }
    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        item = transform.FindChild("Item").gameObject;
        scoreImage = transform.FindChild("Guage/Guage").GetComponent<Image>();
    }

    void Update()
    {
        if (gameManager.GetStart())
        {
            if (score < 1.0f)
            {
                SetScore(score + 0.001f);
            }
        }
    }

    IEnumerator WaitForRotate()
    {
        yield return new WaitForSeconds(0.5f);
        isRotate = false;
    }
}
