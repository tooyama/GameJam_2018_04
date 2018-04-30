using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour 
{
    [SerializeField]
    int id = 1;
    PlayerManager playerManager;
    List<BlockManager> blockManagers = new List<BlockManager>();

    public int GetID()
    {
        return id;
    }

    public void DeleteAll()
    {
        Destroy(gameObject);
    }

	void Start () 
    {
        playerManager = GetComponentInChildren<PlayerManager>();
        foreach(BlockManager b in GetComponentsInChildren<BlockManager>())
        {
            blockManagers.Add(b);
        }
	}
}
