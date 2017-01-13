using UnityEngine;
using System.Collections;

public class GrenadeExplosion : MonoBehaviour {

    private Collider[] hitColliders;
    public float blastRadius;
    public float explosionPower;
    public LayerMask explosionLayers;
    private float destroyTime = 4f;
    private LayerMask grenadeSkip = 1 << 9 | 1 << 12;
	
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        ExplosionWork(col.contacts[0].point);
        Destroy(gameObject);
        
    }
    void ExplosionWork(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayers);
        foreach (Collider hitCol in hitColliders)
        {
            if(hitCol.GetComponent<NavMeshAgent>()!=null)
            {
                hitCol.GetComponent<NavMeshAgent>().enabled = false;
            }
            if (hitCol.GetComponent<Rigidbody>() != null)
            {
                hitCol.GetComponent<Rigidbody>().isKinematic = false;
                hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1f, ForceMode.Impulse);
            }
            if(hitCol.CompareTag("Enemy"))
            {
                Destroy(hitCol.gameObject, destroyTime);
            }
        }
    }
}
