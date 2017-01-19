using UnityEngine;
using System.Collections; 
namespace Chp2{ 

	public class EnemyNavFlee : MonoBehaviour {

        public bool isFleeing;
        private EnemyMaster enemyMaster;
        private UnityEngine.AI.NavMeshAgent myNavMeshAgent;
        private UnityEngine.AI.NavMeshHit navHit;
        private Transform myTransform;
        public Transform fleeTarget;
        private Vector3 runPosition;
        private Vector3 directionToPlayer;
        public float fleeRange = 25;
        private float checkRate;
        private float nextCheck;

		void OnEnable()
		{
            SetInit();
            enemyMaster.EventEnemyDie += DisableThis;
            enemyMaster.EventEnemySetTarget += SetFleeTarget;
            enemyMaster.EventEnemyHealthLow += IShouldFlee;
            enemyMaster.EventEnemyHealthRecover += IShouldStopFleeing;
		}

		void OnDisable()
		{
            enemyMaster.EventEnemyDie -= DisableThis;
            enemyMaster.EventEnemySetTarget -= SetFleeTarget;
            enemyMaster.EventEnemyHealthLow -= IShouldFlee;
            enemyMaster.EventEnemyHealthRecover -= IShouldStopFleeing;
		}
		
		// Use this for initialization
		void Start () {
		
		}
		
		void SetInit()
		{
            enemyMaster = GetComponent<EnemyMaster>();
            myTransform = transform;

            if (GetComponent<UnityEngine.AI.NavMeshAgent>())
            {
                myNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            }

            checkRate = Random.Range(0.3f, 0.4f);
		}

		// Update is called once per frame
		void Update () {
            if (Time.time > nextCheck)
            {
                nextCheck = Time.time + checkRate;

                CheckIfIShouldFlee();
            }
		}
        void SetFleeTarget(Transform target)
        {
            fleeTarget = target;
        }
        void IShouldFlee()
        {
            isFleeing = true;

            if (GetComponent<EnemyNavPursue>() != null)
                GetComponent<EnemyNavPursue>().enabled = false;            
        }
        void IShouldStopFleeing()
        {
            isFleeing = false;

            if (GetComponent<EnemyNavPursue>() != null)
                GetComponent<EnemyNavPursue>().enabled = true;
        }

        void CheckIfIShouldFlee()
        {
            if (isFleeing)
            {
                if(fleeTarget !=null && !enemyMaster.isOnRoute && !enemyMaster.isNavPaused){
                    if (FleeTarget(out runPosition) && Vector3.Distance(myTransform.position,fleeTarget.position) < fleeRange)
                    {
                        myNavMeshAgent.SetDestination(runPosition);
                        enemyMaster.CallEventEnemyWalking();
                        enemyMaster.isOnRoute = true;
                    }
                }
            }
        }

        bool FleeTarget(out Vector3 result)
        {
            directionToPlayer = myTransform.position - fleeTarget.position;
            Vector3 checkPos = myTransform.position + directionToPlayer;

            if(UnityEngine.AI.NavMesh.SamplePosition(checkPos, out navHit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
            {
                result = navHit.position;
                return true;
            }
            else
            {
                result = myTransform.position;
                return false;
            }
        }
        void DisableThis()
        {
            this.enabled = false;
        }
	}
}
