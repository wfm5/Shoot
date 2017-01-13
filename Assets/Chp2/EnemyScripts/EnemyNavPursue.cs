using UnityEngine;
using System.Collections;
namespace Chp2{
	public class EnemyNavPursue : MonoBehaviour {

        private EnemyMaster enemyMaster;
        private NavMeshAgent myNavMeshAgent;
        private float checkRate;
        private float nextCheck;

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
		    if(Time.time >nextCheck)
            {
                nextCheck = Time.time + checkRate;
                TryToChaseTarget();
            }
		}
		void SetInit()
		{
            enemyMaster = GetComponent<EnemyMaster>();
            if (GetComponent<NavMeshAgent>() != null)
            {
                myNavMeshAgent = GetComponent<NavMeshAgent>();
            }
            checkRate = Random.Range(0.1f, 0.2f);
		}
        void TryToChaseTarget()
        {
            if (enemyMaster.myTarget != null && myNavMeshAgent != null && !enemyMaster.isNavPaused)
            {
                myNavMeshAgent.SetDestination(enemyMaster.myTarget.position);

                if (myNavMeshAgent.remainingDistance > myNavMeshAgent.stoppingDistance)
                {
                    enemyMaster.CallEventEnemyWalking();
                    enemyMaster.isOnRoute = true;
                }
            }
        }
        void DisableThis()
        {
            if (myNavMeshAgent != null)
            {
                this.enabled = false;
            }

            this.enabled = false;
        }
	}
}