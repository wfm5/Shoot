using UnityEngine;
using System.Collections;
namespace Chp2{
	public class Enemy_Animation : MonoBehaviour {

        private EnemyMaster enemyMaster;
        private Animator myAnimator;

		void OnEnable()
		{
            SetInit();
            enemyMaster.EventEnemyDie += DisableAnimator;
            enemyMaster.EventEnemyWalking += SetAnimationToWalk;
            enemyMaster.EventEnemyReachedNavTarget += SetAnimationToIdle;
            enemyMaster.EventEnemyAttack += SetAnimationToAttack;
            enemyMaster.EventEnemyDeductHealth += SetAnimationToStruck;
		}
		void OnDisable()
		{
            enemyMaster.EventEnemyDie -= DisableAnimator;
            enemyMaster.EventEnemyWalking -= SetAnimationToWalk;
            enemyMaster.EventEnemyReachedNavTarget -= SetAnimationToIdle;
            enemyMaster.EventEnemyAttack -= SetAnimationToAttack;
            enemyMaster.EventEnemyDeductHealth -= SetAnimationToStruck;
		}
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void SetInit()
		{
            enemyMaster = GetComponent<EnemyMaster>();

            if(GetComponent<Animator>() !=null)
            {
                myAnimator = GetComponent<Animator>();
            }
		}
        void SetAnimationToWalk()
        {
            if (myAnimator != null && myAnimator.enabled)
            {
                myAnimator.SetBool("isPursuing", true);
            }
        }
        void SetAnimationToIdle()
        {
            if (myAnimator != null && myAnimator.enabled)
            {
                myAnimator.SetBool("isPursuing", false);
            }
        }
        void SetAnimationToAttack()
        {
            if (myAnimator != null && myAnimator.enabled)
            {
                myAnimator.SetTrigger("Attack");
            }
        }
        void SetAnimationToStruck(int dummy)
        {
            if (myAnimator != null )
            {
                if(myAnimator.enabled)
                {
                      myAnimator.SetTrigger("Struck");
                }
            }
        }
        void DisableAnimator()
        {
            if(myAnimator!=null)
            {
                myAnimator.enabled = false;
            }
        }
	}
}