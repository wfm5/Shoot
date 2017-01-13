using UnityEngine;
using System.Collections;

namespace Chapter1{
    public class WalkThroughWall : MonoBehaviour 
    {

        private GameManager_EventMaster EventMasterScript;
        void OnAwake(){
            
        }
        void Start()
        {
            
        }
        void SetInit()
        {
            EventMasterScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();

        }
        void OnEnable()
        {
            SetInit();
            EventMasterScript.myGeneralEvent += SetLayerToNotSolid;
        }

        void OnDisable()
        {
            EventMasterScript.myGeneralEvent -= SetLayerToNotSolid;
        }

        public void SetLayerToNotSolid()
        {
            gameObject.layer = LayerMask.NameToLayer("Not Solid");

        }
    }
}