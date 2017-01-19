using UnityEngine;
using System.Collections;
namespace Chp2{
	public class Enemy_Health : MonoBehaviour {

        private EnemyMaster enemyMaster;
        public int enemyHealth;
        public float healthLow = 25;

		void OnEnable()
		{
            SetInit();
            enemyMaster.EventEnemyDeductHealth += DeductHealth;
            enemyMaster.EventEnemyIncreaseHealth += IncreaseHealth;

		}
		void OnDisable()
		{
            enemyMaster.EventEnemyDeductHealth -= DeductHealth;
            enemyMaster.EventEnemyIncreaseHealth -= IncreaseHealth;

		}
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
            CheckHealthFraction();
		}
		void SetInit()
		{
            enemyMaster = GetComponent<EnemyMaster>();
		}
        void DeductHealth(int healthChange)
        {
            enemyHealth -= healthChange;
            if(enemyHealth <0)
            {
                enemyHealth = 0;
                enemyMaster.CallEventEnemyDie();
                Destroy(gameObject, Random.Range(10f, 20f));  
            }
        }
        void CheckHealthFraction()
        {
            if(enemyHealth <= healthLow && enemyHealth >0){
                enemyMaster.CallEventEnemyHealthLow();
//                Debug.Log("IM LOW??");
            }
            else if(enemyHealth > healthLow)
            {
                enemyMaster.CallEventEnemyHealthRecover();
            }
        }
        void IncreaseHealth(int healthChange)
        {
            enemyHealth += healthChange;
            if (enemyHealth > 100)
            {
                enemyHealth = 100;
            }

            CheckHealthFraction();
        }
	}
}