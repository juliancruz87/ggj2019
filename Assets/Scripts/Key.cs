using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Key : MonoBehaviour 
{
    public void ClickInKey(BaseEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
