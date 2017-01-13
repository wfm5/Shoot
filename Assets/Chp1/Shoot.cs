using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    private float fireRate = 0.3f;
    private float nextFire;
    private RaycastHit hit;
    private float range = 3000;
    public Transform myTransform;
    public int arrayDistmultiplier;

	// Use this for initialization
	void Start () {
        SetReferences();
	}

    void SetReferences()
    {
        myTransform = transform;
        arrayDistmultiplier = 10;
    }
	// Update is called once per frame
	void Update () {
        CheckForInput();
	}
    void CheckForInput()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Debug.DrawRay(myTransform.position, myTransform.forward*arrayDistmultiplier, Color.green, 3f);
            if (Physics.Raycast(myTransform.position, myTransform.forward*arrayDistmultiplier, out hit, range))
            {
                Debug.Log(hit.transform.name);
            }
            else
            {
                Debug.Log("no hit");
            }
            nextFire = Time.time + fireRate;            
        } 
    }
}
