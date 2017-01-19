using UnityEngine;
using System.Collections;
namespace Chp2{
	public class EnemyNavDestinationReached : MonoBehaviour {

        private EnemyMaster enemyMaster;
        private UnityEngine.AI.NavMeshAgent myNavMeshAgent;
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
            if (Time.time > nextCheck)
            {
                nextCheck = Time.time + checkRate;
                CheckIfDestReached();
            }
            
		}
        void SetInit()
        {
            enemyMaster = GetComponent<EnemyMaster>();
            if (GetComponent<UnityEngine.AI.NavMeshAgent>() != null)
            {
                myNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            }
            checkRate = Random.Range(0.3f, 0.4f);
        }
        void CheckIfDestReached()
        {
            if(myNavMeshAgent.remainingDistance < myNavMeshAgent.stoppingDistance)
            {
                enemyMaster.isOnRoute = false;
                enemyMaster.CallEventEnemyReachedNavTarget();
            }
        }
        void DisableThis()
        {
            this.enabled = false;
        }
	}
}