using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMe : MonoBehaviour {

    public GameObject OSC;

    float angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float income = OSC.GetComponent<oscReceive>().incomeValue;

        //transform.localScale = new Vector3(income * 300, income * 300, income * 300);

        transform.RotateAround(transform.position,new Vector3(Random.Range(-1,1),Random.Range(-1, 1),Random.Range(-1, 1)),angle);

        if(income > 0.1){
            GameObject newcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newcube.AddComponent<Rigidbody>();
            newcube.transform.position = transform.position + Vector3.down;

        }
        angle += 0.01f;
	}
}
