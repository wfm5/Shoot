using UnityEngine;
using System.Collections; 
namespace Chp2{ 

	public class EnemyCollisionField : MonoBehaviour {

        private EnemyMaster enemyMaster;
        private Rigidbody rigibodyStrikingMe;
        private int damageToApply;
        public float massRequirement = 10f;
        public float speedRequirement = 2f;
        private float damageFactor = 0.1f;

		void OnEnable()
		{
            SetInit();
            enemyMaster.EventEnemyDie += DisableThis;
		}

		void OnDisable()
		{
            enemyMaster.EventEnemyDie -= DisableThis;
		}
        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Rigidbody>()!=null)
            {
                //Debug.Log("touch");
                rigibodyStrikingMe = other.GetComponent<Rigidbody>();
                if(rigibodyStrikingMe.mass >= massRequirement &&
                    rigibodyStrikingMe.velocity.sqrMagnitude > speedRequirement * speedRequirement)
                {
                    damageToApply = (int) (damageFactor*rigibodyStrikingMe.mass*rigibodyStrikingMe.velocity.magnitude);
                    enemyMaster.CallEventDeductHealth(damageToApply);
                }else
                {
                    //rigibodyStrikingMe.velocity.sqrMagnitude < speedRequirement * speedRequirement)

                    //Debug.Log("bigger pls");
                }
            }
        }
		// Use this for initialization
		void Start () {
		
		}
		
		void SetInit()
		{
            enemyMaster = transform.root.GetComponent<EnemyMaster>();
		}

		// Update is called once per frame
		void Update () {
		
		}
        void DisableThis()
        {
            gameObject.SetActive(false);
        }
	}
}
