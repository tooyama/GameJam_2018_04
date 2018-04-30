using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    int id;
    int stageId = 0;
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    FieldSelector fieldSelector;
    [SerializeField]
    GameObject[] ballObjects;
    [SerializeField]
    AudioClip[] clips;
    UIManager uiManager;
    Transform shotPos;
    Rigidbody2D rb;
    GameManager gameManager;
    AudioSource audioSource;

    public void SetStart()
    {
        GameObject ball = Instantiate(ballObjects[0], shotPos.position, transform.rotation) as GameObject;
        ball.transform.parent = transform.parent;
    }

	void Start () 
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        id = GetComponentInParent<FieldManager>().GetID();
        rb = GetComponent<Rigidbody2D>();
        shotPos = transform.FindChild("shotPos");
        uiManager = GameObject.Find("UI/Panel/Player"+id).GetComponent<UIManager>();
	}

    void Update()
    {
        if (gameManager.GetStart())
        {
            if (Input.GetButtonDown("Fire" + id))
            {
                int fireNum = uiManager.SetFire(stageId);
                if (fireNum != -1)
                {
                    GameObject ball = Instantiate(ballObjects[fireNum], shotPos.position, transform.rotation) as GameObject;
                    ball.transform.parent = transform.parent;
                }
            }
            /*
            if (Input.GetButtonDown("Select" + id))
            {
                uiManager.RotateAngle(1);
            }

            if (Input.GetButtonDown("Select_Rev" + id))
            {
                uiManager.RotateAngle(-1);
            }
            */
        }
        else
        {
            if (Input.GetButtonDown("Fire" + id))
            { 
                gameManager.SetPlayer(id);
                audioSource.PlayOneShot(clips[1]);
            }

            if (Input.GetButtonDown("Select" + id))
            {
                stageId = fieldSelector.SetStage(1);
                audioSource.PlayOneShot(clips[0]);
            }

            if (Input.GetButtonDown("Select_Rev" + id))
            {
                stageId = fieldSelector.SetStage(-1);
                audioSource.PlayOneShot(clips[0]);
            }
        }
    }

    void FixedUpdate () 
    {
        if (gameManager.GetStart())
        {
            float y = Input.GetAxis("Vertical" + id);

            rb.velocity = new Vector2(0, y * speed);
        }
	}
}
