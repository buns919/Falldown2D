using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] private float verticalMoveSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveVector = Vector3.up * (Time.deltaTime * verticalMoveSpeed);
        transform.Translate(moveVector);
    }
}
