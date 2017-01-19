using UnityEngine;
using System.Collections;
namespace Chp2{
	public class EnemyNavPause : MonoBehaviour {

        private EnemyMaster enemyMaster;
        private UnityEngine.AI.NavMeshAgent myNavMeshAgent;
        private float checkRate;
        private float nextCheck;
        private float pauseTime = 1;

		void OnEnable()
		{
            SetInit();
            enemyMaster.EventEnemyDie += DisableThis;
            enemyMaster.EventEnemyDeductHealth += PauseNavMeshAgent;

		}
		void OnDisable()
		{
            enemyMaster.EventEnemyDie -= DisableThis;
            enemyMaster.EventEnemyDeductHealth -= PauseNavMeshAgent;
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

        void PauseNavMeshAgent(int dummy)
        {
            if(myNavMeshAgent!=null)
            {
                if (myNavMeshAgent.enabled)
                {
                    myNavMeshAgent.ResetPath();
                    enemyMaster.isNavPaused = true;
                    StartCoroutine(RestartNavMeshAgent());
                }
            }
        }
        IEnumerator RestartNavMeshAgent()
        {
            yield return new WaitForSeconds(pauseTime);
            enemyMaster.isNavPaused = false;
        }
        void DisableThis()
        {
            StopAllCoroutines();
        }
	}
}