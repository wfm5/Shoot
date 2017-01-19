using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chp2
{
    public class EnemyRagdoll_Activation : MonoBehaviour
    {
        private EnemyMaster enemyMaster;
        private Collider myCollider;
        private Rigidbody myRigibody;

        void OnEnable()
        {
            SetInit();
            enemyMaster.EventEnemyDie += ActivateRagdoll;
        }
        void OnDisable()
        {
            enemyMaster.EventEnemyDie -= ActivateRagdoll;
        }
        void SetInit(){
            enemyMaster = transform.root.GetComponent<EnemyMaster>();

            if(GetComponent<Collider>()!=null){
                myCollider = GetComponent<Collider>();
            }
            
            if (GetComponent<Rigidbody>() != null)
            {
                myRigibody = GetComponent<Rigidbody>();
            }
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void ActivateRagdoll()
        {
            if (myRigibody != null)
            {
                myRigibody.isKinematic = false;
                myRigibody.useGravity = true;
            }
            if (myCollider != null)
            {
                myCollider.isTrigger = false;
                myCollider.enabled = true;

            }
        }
    }
}