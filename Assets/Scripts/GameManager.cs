using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    [SerializeField]
    GameObject horrorSounds;
    [SerializeField]
    Light mainLight;
    public GameObject enemiesContainer;



    Inventory inventory;
	private void Start () 
    {
        inventory = GetComponent<Inventory>();
        inventory.onCompleted += GameFinish;
	}

	private void OnDestroy()
	{
        inventory.onCompleted -= GameFinish;
	}

	private void GameFinish ()
    {
        enemiesContainer.SetActive(false);
        horrorSounds.SetActive(false);
        mainLight.enabled = true;
        print("game end ");
    }



}