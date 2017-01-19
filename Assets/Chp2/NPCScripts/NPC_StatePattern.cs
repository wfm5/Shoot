using UnityEngine;
using System.Collections; 
namespace Chp2{ 

	public class NPC_StatePattern : MonoBehaviour {

        private float checkRate = 0.1f;
        private float nextCheck;
        public float sightRange = 40f;
        public float detectBehindRange = 5f;
        public float meleeAttackRange = 7f;
        public float meleeAttackDamage = 10f;
        public float rangeAttackRange = 35f;
        public float rangeAttackDamage = 5f;
        public float rangeAttackSpread = 0.5f;
        public float attackRate = 0.4f;
        public float nextAttack;
        public float fleeRange = 25f;
        public float offset = 0.4f;
        public float requiredDetectionCount = 15f;

        public bool hasRangeAttack;
        public bool hasMeleeAttack;
        public bool isMeleeAttacking;

        public Transform myFollowTarget;
        [HideInInspector]
        public Transform pursueTarget;
        [HideInInspector]
        public Vector3 locationOfInterest;
        [HideInInspector]
        public Vector3 wanderTarget;
        [HideInInspector]
        public Transform myAttacker;
        
        //used for sight
        public LayerMask sightLayers;
        public LayerMask myEnemyLayers;
        public LayerMask myFriendlyLayers;
        public string[] myEnemyTags;
        public string[] myFriendlyTags;

        //References
        public Transform[] waypoints;
        public Transform head;
        public MeshRenderer meshRendererFlag;
        public GameObject rangeWeapon;
        public NPC_Master npcMaster;
        [HideInInspector]
        public UnityEngine.AI.NavMeshAgent myNavMeshAgent;

        //Used for state Ai
        public NPCState_Interface currentState;
        public NPCState_Interface capturedState;
        public NPCState_Patrol patrolState;
        public NPCState_Alert alertState;
        public NPCState_Pursue pursueState;
        public NPCState_MeleeAttack meleeAttackState;
        public NPCState_RangedAttack rangeAttackState;
        public NPCState_Flee fleeState;
        public NPCState_Struck struckState;
        public NPCState_InvestigateHarm investigateHarmState;
        public NPCState_Follow followState;

        void Awake()//first thing run no matter what
        {
            SetUpStateReferences();
            SetInit();
            npcMaster.EventNpcLowHealth += ActivateFleeState;
            npcMaster.EventNpcHealthRecovered += ActivatePatrolState;
            npcMaster.EventNpcDeductHealth += ActivateStruckState;

        }
		void OnEnable()
		{
		}

		void OnDisable()
		{
            npcMaster.EventNpcLowHealth -= ActivateFleeState;
            npcMaster.EventNpcHealthRecovered -= ActivatePatrolState;
            npcMaster.EventNpcDeductHealth -= ActivateStruckState;
            StopAllCoroutines();
		}
		
		// Use this for initialization
		void Start () {
            SetInit();
		}
		
		void SetInit()
		{
            npcMaster = GetComponent<NPC_Master>();
            myNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            ActivatePatrolState();
		}
        void SetUpStateReferences()
        {
            patrolState = new NPCState_Patrol(this);
        }
		// Update is called once per frame
		void Update () {
            CarryOutUpdateState();
		}
        void CarryOutUpdateState()
        {
            if(Time.time > nextCheck)
            {
                nextCheck = Time.time + checkRate;
                currentState.UpdateState();
            }
        }
        void ActivatePatrolState()
        {
            currentState = patrolState;
        }
        
        void ActivateFleeState()
        {
            if (currentState == struckState)
            {
                capturedState = fleeState;
                return;
            }
        }
        void ActivateStruckState(int dummy)
        {
            StopAllCoroutines();

            if (currentState != struckState) //prevent infinite lock
            {
                capturedState = currentState;
            }

            if (rangeWeapon != null) //Change or remove if you have proper gun holding anim
            {
                rangeWeapon.SetActive(false);
            }
            if (myNavMeshAgent.enabled)
            {
                myNavMeshAgent.Stop();
            }

            currentState = struckState;

            npcMaster.CallEventNpcStruckAnim();

            StartCoroutine(RecoverFromStruckState());

        }

        IEnumerator RecoverFromStruckState()
        {
            yield return new WaitForSeconds(1.5f);

            npcMaster.CallEventNpcRecoveredAnim();
            
            if(rangeWeapon != null)
            {
                rangeWeapon.SetActive(true);
            }

            if(myNavMeshAgent.enabled)
            {
                myNavMeshAgent.Resume();
            }

            currentState = capturedState;
        }

        public void OnEnemyAttack() //Called by attack animation
        {
            if (pursueTarget != null)
            {
                if (Vector3.Distance(transform.position, pursueTarget.position) <= meleeAttackRange)
                {
                    Vector3 toOther = pursueTarget.position - transform.position;
                    if (Vector3.Dot(toOther, transform.forward) > 0.5f)
                    {
                        pursueTarget.SendMessage("CallEventPlayerHealthDeduction", meleeAttackDamage, SendMessageOptions.DontRequireReceiver);
                        pursueTarget.SendMessage("ProcessDamage", meleeAttackDamage, SendMessageOptions.DontRequireReceiver);
                    }                    
                }
            }

            isMeleeAttacking = false;
        }

        public void SetMyAttacker(Transform attacker)
        {
            myAttacker = attacker;
        }

        public void Distract(Vector3 distractionPos)
        {
            locationOfInterest = distractionPos;

            if (currentState == patrolState)
            {
                currentState = alertState;
            }
        }
	}
}
