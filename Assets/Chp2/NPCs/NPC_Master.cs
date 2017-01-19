﻿using UnityEngine;
using System.Collections; 
namespace Chp2{ 

	public class NPC_Master : MonoBehaviour {

        public delegate void GeneralEventHandler();
        public event GeneralEventHandler EventNpcDie;
        public event GeneralEventHandler EventNpcLowHealth;
        public event GeneralEventHandler EventNpcHealthRecovered;
        public event GeneralEventHandler EventNpcWalkAnim;
        public event GeneralEventHandler EventNpcStruckAnim;
        public event GeneralEventHandler EventNpcAttackAnim;
        public event GeneralEventHandler EventNpcRecoveredAnim;
        public event GeneralEventHandler EventNpcIdleAnim;

        public delegate void HealthEventHandler(int health);
        public event HealthEventHandler EventNpcIncreaseHealth;
        public event HealthEventHandler EventNpcDeductHealth;

        public string animationBoolPursuing = "isPursuing";
        public string animationTriggerStruck = "Struck";
        public string animationTriggerMelee = "Attack";
        public string animationTriggerRecovered = "Recovered";

        //Action Calls
        public void CallEventNpcDie()
        {
            if (EventNpcDie != null)
            {
                EventNpcDie();
            }
        }
        public void CallEventNpcLowHealth()
        {
            if (EventNpcLowHealth != null)
            {
                EventNpcLowHealth();
            }
        }
        public void CallEventNpcHealthRecovered()
        {
            if (EventNpcHealthRecovered != null)
            {
                EventNpcHealthRecovered();
            }
        }
        public void CallEventNpcWalkAnim()
        {
            if (EventNpcWalkAnim != null)
            {
                EventNpcWalkAnim();
            }
        }
        public void CallEventNpcStruckAnim()
        {
            if (EventNpcStruckAnim != null)
            {
                EventNpcStruckAnim();
            }
        }
        public void CallEventNpcAttackAnim()
        {
            if (EventNpcAttackAnim != null)
            {
                EventNpcAttackAnim();
            }
        }
        public void CallEventNpcRecoveredAnim()
        {
            if (EventNpcRecoveredAnim != null)
            {
                EventNpcRecoveredAnim();
            }
        }
        public void CallEventNpcIdleAnim()
        {
            if (EventNpcIdleAnim != null)
            {
                EventNpcIdleAnim();
            }
        }
        //Health Calls
        public void CallEventNpcIncreaseHealth(int health)
        {
            if (EventNpcIncreaseHealth != null)
            {
                EventNpcIncreaseHealth(health);
            }
        }
        public void CallEventNpcDeductHealth(int health)
        {
            if (EventNpcDeductHealth != null)
            {
                EventNpcDeductHealth(health);
            }
        }
	}
}