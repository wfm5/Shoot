using UnityEngine;
using System.Collections;
namespace Chp2{
	public class EnemyDetection : MonoBehaviour {

        private EnemyMaster enemyMaster;
        private Transform myTransform;
        public Transform head;
        public LayerMask playerLayer;
        public LayerMask sightLayer;
        private float checkRate;
        private float nextCheck;
        private float detectRadius = 300;
        private RaycastHit hit;

		void OnEnable()
		{
            SetInit();
            enemyMaster.EventEnemyDie += DisableThis;
		}
		void OnDisable()
		{
            enemyMaster.EventEnemyDie -= DisableThis;
		}
		// Update is called once per frame
		void Update () {
            CarryOutDetection();
		}
		void SetInit()
		{
            enemyMaster = GetComponent<EnemyMaster>();
            myTransform = transform;

            if (head == null)
            {
                head = myTransform;
            }

            checkRate = Random.Range(0.8f, 1.2f);
		}
        void CarryOutDetection()
        {
            if (Time.time > nextCheck)
            {
                nextCheck = Time.time + checkRate;

                Collider[] colliders = Physics.OverlapSphere(myTransform.position, detectRadius, playerLayer);
                if (colliders.Length > 0)
                {
                    foreach (Collider potentialTargetCollider in colliders)
                    {
                        if (potentialTargetCollider.CompareTag(GameManager_References._playerTag))
                        {
                            if (CanPotentialTargetBeSeen(potentialTargetCollider.transform))
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    enemyMaster.CallEventEnemyLossTarget();
                }
            }
        }
        void DisableThis()
        {
            this.enabled = false;
        }
        bool CanPotentialTargetBeSeen(Transform potentialTarget)
        {
            if (Physics.Linecast(head.position, potentialTarget.position, out hit, sightLayer))
            {
                if (hit.transform == potentialTarget)
                {
                    enemyMaster.CallEventEnemySetNavTarget(potentialTarget);
                    return true;
                }
                else
                {
                    enemyMaster.CallEventEnemyLossTarget();
                    return false;
                }

            }
            else
            {
                enemyMaster.CallEventEnemyLossTarget();
                return false;
            }
        }
	}
}