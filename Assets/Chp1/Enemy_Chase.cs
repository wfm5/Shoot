using UnityEngine;
using System.Collections;

public class Enemy_Chase : MonoBehaviour {

    private Transform myTransform;
    private NavMeshAgent myNavMeshAgent;
    public LayerMask detectionLayer;
    private Collider[] hitColliders;
    private float checkRate;
    private float nextCheck;
    private float detectionRadius = 50;

	// Use this for initialization
	void Start () {
        SetInit();
	}
	
	// Update is called once per frame
	void Update () {
        CheckIfPlayerInRange();
	}

    void SetInit()
    {
        myTransform = transform;
        myNavMeshAgent = GetComponent <NavMeshAgent>();
        checkRate = Random.Range(0.8f,1.2f);

    }
    void CheckIfPlayerInRange()
    {
        if(Time.time>nextCheck && myNavMeshAgent.enabled == true)
        {
            nextCheck = Time.time + checkRate;

            hitColliders = Physics.OverlapSphere(myTransform.position, detectionRadius, detectionLayer);

            if(hitColliders.Length >0){
                myNavMeshAgent.SetDestination(hitColliders[0].transform.position);

            }
        }
    }
}
