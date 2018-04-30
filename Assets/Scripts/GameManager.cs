using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    PlayerManager player1;
    PlayerManager player2;
    bool isStart = false;
    bool isStart1 = false;
    bool isStart2 = false;
    bool isEnd = false;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player1 = GameObject.Find("Blocks_Player1/Player1").GetComponent<PlayerManager>();
        player2 = GameObject.Find("Blocks_Player2/Player2").GetComponent<PlayerManager>();
    }

    void SetStart()
    {
        audioSource.Play();
        isStart = true;
        player1.SetStart();
        player2.SetStart();
    }

    public void SetPlayer(int id)
    {
        if(id == 1)
        {
            if(isStart2)
            {
                SetStart();
            }
            else
            {
                isStart1 = true;
            }
        }
        else
        {
            if (isStart1)
            {
                SetStart();
            }
            else
            {
                isStart2 = true;
            }
        }
    }

    public bool GetStart()
    {
        return isStart;
    }

    public void SetEnd()
    {
        audioSource.Stop();
        isEnd = true;
    }

    public bool GetEnd()
    {
        return isEnd;
    }

	void Update () 
    {
        if(isEnd)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Main");
            }
        }
	}
}
