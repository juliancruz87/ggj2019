using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityScript.Steps;

public class PlayerController : MonoBehaviour
{

	public Transform point;
	public Transform player;
	public LayerMask layerMaskFloor;
	public LayerMask layerMaskKeys;
	public Light spotLight;
	private Vector3 castDown =  new Vector3(0, 0.5f, 0);
	public float timeToTurnOffLight = 10;
	public int accelToTurnOnLight = 10;
	
	public Vector2 timeRangeLightOff = new Vector2(5,10);

	public float devicesAccel;
		
	void Start()
	{
		//spotLight = gameObject.GetComponentInChildren<Light>();
		timeToTurnOffLight = 7;
	}

	void CheckForLight()
	{
		
		
		if (timeToTurnOffLight < 0 )
		{
			spotLight.enabled = false;
			print("off light");
		}
		else
		{
			timeToTurnOffLight -= Time.deltaTime;
		}

		if (GvrControllerInput.Accel.magnitude > accelToTurnOnLight)
		{
			if(spotLight.enabled == false)
				TurnOnlight();
		}
	}

	void TurnOnlight()
	{
		spotLight.enabled = true;
		timeToTurnOffLight = Random.Range(5 , 15 );
		print(timeRangeLightOff);
		print("ON light");
	}

	void Update ()
	{
		
		CheckForLight();

		devicesAccel = GvrControllerInput.Accel.magnitude;


        if (Input.GetKeyUp(KeyCode.A) || GvrControllerInput.ClickButtonUp ||  GvrControllerInput.AppButtonUp ) 
		{
			//var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
			//go.transform.localScale = new Vector3(.2f ,.2f,.2f  );
			//go.transform.position = point.position;
			
			print("ClickButtonUp");
			
			var pos = new Vector3(point.position.x,
								  player.position.y,
								  point.position.z
				);
			
			RaycastHit hit;
			
			if (Physics.Linecast( point.position + castDown , point.position -  castDown, out hit ,  layerMaskFloor )) 
			{
				print("find floor pos ");
				player.position = pos;
			}
			
			if (Physics.Linecast( point.position + castDown , point.position -  castDown, out hit ,  layerMaskKeys )) 
			{
				print("hit Keys");
				hit.collider.gameObject.SetActive(false);
			}
			
			
		}

		if ( GvrControllerInput.AppButtonUp )
		{
			print("AppButtonUp");
		}
		
	}

	

	
	
	
	
}
