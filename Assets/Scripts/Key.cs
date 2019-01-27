using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Key : MonoBehaviour 
{
    [SerializeField]
    private GameObject particle;
    private Inventory inventory;

	private void Start()
	{
        inventory = FindObjectOfType<Inventory>();
	}

	public void ClickInKey(BaseEventData eventData)
    {
        particle.SetActive(false);
        gameObject.SetActive(false);
        inventory.Collect(this);
    }
}
