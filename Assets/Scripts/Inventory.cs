using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
    public event System.Action onCompleted;
    Key[] maxKeys;
    private List<Key> collectedKeys;

	private void Start()
	{
        collectedKeys = new List<Key>();
        maxKeys = FindObjectsOfType<Key>();
	}

    public void Collect (Key key)
    {
        if (!collectedKeys.Contains(key))
            collectedKeys.Add(key);
                     
        if(collectedKeys.Count == maxKeys.Length)
        {         
			if (onCompleted != null)
				onCompleted();
        }
    }
}