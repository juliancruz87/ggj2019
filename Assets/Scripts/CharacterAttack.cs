using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
	public  Animator anim;
	public GameObject player;	
	// Use this for initialization
	void Start ()
	{

		/*var playerGO =  GameObject.FindObjectOfType<PlayerController>();
		if (playerGO)
			player = playerGO.gameObject;
			*/          


	}
	
	// Update is called once per frame
	void Update ()
	{


	if ( Input.GetKeyUp(KeyCode.Space)|| Vector3.Distance(player.transform.position, transform.position) < 2)
	{
            print("attack");
            anim.SetTrigger("Attack");
	}   

	}
}
