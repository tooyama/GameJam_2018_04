using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSelector : MonoBehaviour 
{
    [SerializeField]
    Transform[] pos;
    int num = 0;
    bool isMove = false;

	public int SetStage(int _num)
    {
        if (isMove) return num;

        StopCoroutine(WaitForMove());

        num += _num;

        if (2 < num)
        {
            num = 0;
        }
        else if (num < 0)
        {
            num = 2;
        }

        iTween.MoveTo(gameObject, pos[num].position, 1.0f);

        return num;
    }

    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(1.0f);
        isMove = false;
    }
}
