using UnityEngine;
using System.Collections;

public class ThrowGrenade : MonoBehaviour {

    public GameObject grenadePrefab;
    public Transform myTransform;
    public float propulsionForce;
    void SpawnGrenade()
    {
        GameObject go = (GameObject)Instantiate(grenadePrefab,myTransform.TransformPoint(0f,0f,0.5f),myTransform.rotation);
        go.GetComponent<Rigidbody>().AddForce(myTransform.forward * propulsionForce, ForceMode.Impulse);

    }
	// Use this for initialization
	void Start () {
	    SetInit();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            SpawnGrenade();
        }
	}
    void SetInit(){
        myTransform = GameObject.Find("Gun").transform;
    }
}
