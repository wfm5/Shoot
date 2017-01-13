using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour {

    private RaycastHit hit;
    public LayerMask detectionLayer;
    private float checkRate = 0.5f;
    private float nextCheck;
    private float range = 5f;
    public Transform myTransform;
    

	// Use this for initialization
	void Start () {
        SetInitReferences();
	}

    void SetInitReferences()
    {
        myTransform = transform;
        detectionLayer = 1 << 10;// 1<<10 | 1<<8 has to be on layer 10 or 8---1<<4 & 1<<5 has to be on layer 4 and 5
    }
	
    // Update is called once per frame
	void Update () {
        DetectItems();
	}
    void DetectItems()
    {
        nextCheck = Time.time + checkRate;

        if (Physics.Raycast(myTransform.position, myTransform.forward, out hit, range, detectionLayer))
        {
            Debug.Log(hit.transform.name+"is an item.");
        }
    }
}
