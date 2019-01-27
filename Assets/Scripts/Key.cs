﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Key : MonoBehaviour 
{
    [SerializeField]
    private GameObject particle;
    public Inventory inventory;

	private void Start()
	{
        //inventory = FindObjectOfType<Inventory>();
	}

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.L)) {

            ClickInKey(null);
        }
    }

    public void ClickInKey(BaseEventData eventData)
    {
        particle.SetActive(false);
        inventory.Collect(this);
        print("Collected key");
        gameObject.SetActive(false);
    }
}
