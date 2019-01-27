using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
	public  Animator anim;

	private GameObject player;	
	// Use this for initialization
	void Start ()
	{

		var playerGO =  GameObject.FindObjectOfType<PlayerController>();
		if (playerGO)
			player = playerGO.gameObject;


	}
	
	// Update is called once per frame
	void Update ()
	{


		if (player && Vector3.Distance(player.transform.position, transform.position) < 1)
		{
			anim.SetTrigger("Attack");
		}

	}
}
