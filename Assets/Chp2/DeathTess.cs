using UnityEngine;
using System.Collections;
namespace Chp2
{
    public class DeathTess : MonoBehaviour
    {
        private GameManager_Master gammaster;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                gammaster = GetComponent<GameManager_Master>();
                gammaster.CallGameOverEvent();
            }
        }
    }
}