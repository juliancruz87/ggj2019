using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRKey : MonoBehaviour
{

	public PlayerController _PlayerController;

	public void ClickInKey(BaseEventData eventData)
	{
		gameObject.SetActive(false);
	}
}
