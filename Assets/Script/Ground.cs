using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    float verticalExtent;
    float horizontalExtent;

    public Transform down;
    public Transform right;
    public Transform left;
	// Use this for initialization
	void Start () {
        verticalExtent = Camera.main.orthographicSize;
        horizontalExtent = verticalExtent*Camera.main.aspect;

        down.localScale =new Vector3(horizontalExtent*2,1,1);
        down.localPosition = new Vector3(transform.localPosition.x, -verticalExtent, transform.localPosition.z);

        right.localScale = new Vector3(1, verticalExtent * 2, 1);
        right.localPosition = new Vector3(horizontalExtent, transform.localPosition.y, transform.localPosition.z);

        left.localScale = new Vector3(1, verticalExtent * 2, 1);
        left.localPosition = new Vector3(-horizontalExtent, transform.localPosition.y, transform.localPosition.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    	
	}
}
