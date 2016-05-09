using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log( Vector3.Angle(transform.position, transform.position + transform.forward * 100));
        //transform.position = transform.position + transform.forward * 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
