using UnityEngine;
using System.Collections; 
namespace Chp2{

    public interface NPCState_Interface
    {
        void UpdateState();
        void ToPatrolState();
        void ToAlertState();
        void ToPursueState();
        void ToMeleeAttackState();
        void ToRangeAttackState();
    }
}
