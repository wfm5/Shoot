using UnityEngine;
using System.Collections;
namespace Chp2{
	public class EnemyMaster : MonoBehaviour {

        public Transform myTarget;

        public bool isOnRoute;
        public bool isNavPaused;

        public delegate void GeneralEventHandler();

        public event GeneralEventHandler EventEnemyDie;
        public event GeneralEventHandler EventEnemyWalking;
        public event GeneralEventHandler EventEnemyReachedNavTarget;
        public event GeneralEventHandler EventEnemyAttack;
        public event GeneralEventHandler EventEnemyLossTarget;

        public delegate void HealthEventHandler(int health);
        public event HealthEventHandler EventEnemyDeductHealth;

        public delegate void NavTargetEventHandler(Transform targetTransform);
        public event NavTargetEventHandler EventEnemySetTarget;

        public void CallEventDeductHealth(int health)
        {
            if (EventEnemyDeductHealth != null)
            {
                EventEnemyDeductHealth(health);
            }
        }
        public void CallEventEnemySetNavTarget(Transform targTransform)
        {
            if(EventEnemySetTarget!=null)
            {
                EventEnemySetTarget(targTransform);
            }
            myTarget = targTransform;
        }
        public void CallEventEnemyDie()
        {
            if (EventEnemyDie != null)
            {
                EventEnemyDie();
            }
        }
        public void CallEventEnemyWalking()
        {
            if (EventEnemyWalking != null)
            {
                EventEnemyWalking();
            }
        }
        public void CallEventEnemyReachedNavTarget()
        {
            if (EventEnemyReachedNavTarget != null)
            {
                EventEnemyReachedNavTarget();
            }
        }               
        public void CallEventEnemyAttack()
        {
            if (EventEnemyAttack != null)
            {
                EventEnemyAttack();
            }
        }
        public void CallEventEnemyLossTarget()
        {
            if (EventEnemyLossTarget != null)
            {
                EventEnemyLossTarget();
            }

            myTarget = null;
        }
	}
}