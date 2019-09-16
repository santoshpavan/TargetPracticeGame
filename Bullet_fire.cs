using UnityEngine;
using System.Collections;

public class Bullet_fire : MonoBehaviour
{
	//getting the required gameobject properties
	public GameObject bulletEmitter;
	public GameObject bullet;

	//speed of the buller
	public float bulletForwardForce;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			//The Bullet instantiation.
			GameObject BulletGameObject;
			Temporary_Bullet_Handler = Instantiate(bullet,bulletEmitter.transform.position,bulletEmitter.transform.rotation) as GameObject;
			
			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = BulletGameObject.GetComponent<Rigidbody>();

			//bullet being pushed
			Temporary_RigidBody.AddForce(transform.forward * bulletForwardForce);
			//Destroy the unncessary components
			Destroy(BulletGameObject, 3f);
		}
	}
}
