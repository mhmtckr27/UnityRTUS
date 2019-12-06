using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attach this script to a ObjectPooler gameobject. 
public class ObjectPoolerScript : MonoBehaviour
{

	public static ObjectPoolerScript currentObjectPoolerScript;
	public GameObject pooledObject;
	public int pooledAmount = 20;

	//if I call for an object that isnt available, will I create a new object and add to pool,will my pool grow/expand ?
	public bool willGrow = true;

	List<GameObject> pooledObjects;

	private void Awake()
	{
		currentObjectPoolerScript = this;
	}

	void Start()
	{
		pooledObjects = new List<GameObject>();
		
		for(int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject) Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}

		if (willGrow)
		{
			GameObject obj = (GameObject) Instantiate(pooledObject);
			pooledObjects.Add(obj);
			return obj;
		}

		return null;
	}


	//in BulletFireScript attached to gun/warship etc. it ffires bullets repeatedly from the gun.

	//void Start()
	//{
	//	InvokeRepeating("Fire", fireTime, fireTime);
	//}

	//void Fire()
	//{
	//	GameObject obj = ObjectPoolerScript.currentObjectPoolerScript.GetPooledObject();

	//	if(obj == null)
	//	{
	//		return;
	//	}

	//	obj.transform.position = transform.position;
	//	obj.transform.rotation = transform.rotation;
	//	obj.SetActive(true);
	//}


}
