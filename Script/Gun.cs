﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnObject;
	
	private void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(bulletPrefab,spawnObject.position,transform.rotation) as GameObject;
            go.GetComponent<Rigidbody>().AddForce(transform.forward * 30,ForceMode.VelocityChange);
        }
	}
}
