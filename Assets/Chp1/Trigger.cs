using UnityEngine;
using System.Collections;

namespace Chapter1{
    public class Trigger : MonoBehaviour
    {

        private WalkThroughWall walkthrough;
        private GameManager_EventMaster eventMasterScript;
        void Start()
        {
            SetInit();
        }
        void SetInit()
        {
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();

        }
        void OnTriggerEnter(Collider other)
        {
            eventMasterScript.CallMyGeneralEvent();
        }
    }
}