using UnityEngine;
using System.Collections;
namespace Chp2{
	public class EnemyTakeDamage : MonoBehaviour {

        private EnemyMaster enemyMaster;
        public int damageMultiplier = 1;
        public bool shouldRemoveCollider;

		void OnEnable()
		{
            SetInit();
            enemyMaster.EventEnemyDie += RemoveThis;
		}
		void OnDisable()
		{
            enemyMaster.EventEnemyDie -= RemoveThis;
		}
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void SetInit()
		{
            enemyMaster = transform.root.GetComponent<EnemyMaster>();
		}
        public void ProcessDamage(int damage)
        {
            int damageToApply = damage * damageMultiplier;
            enemyMaster.CallEventDeductHealth(damageToApply);

        }
        void RemoveThis()
        {
            if (shouldRemoveCollider)
            {
                if (GetComponent <Collider>())
                {
                    Destroy(GetComponent<Rigidbody>());
                }
            }
            Destroy(this);
        }
	}
}