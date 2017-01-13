using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

namespace Chp2
{
    public class GameManager_TogglePlayer : MonoBehaviour
    {
        public FirstPersonController playerController;
        private GameManager_Master gameManagerMaster;

        void OnEnable()
        {
            SetInit();
            gameManagerMaster.MenuToggleEvent += TogglePlayerController;
            gameManagerMaster.InventoryUIToggleEvent += TogglePlayerController;
        }
        void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= TogglePlayerController;
            gameManagerMaster.InventoryUIToggleEvent -= TogglePlayerController;
        }
        void SetInit()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }
        void TogglePlayerController()
        {
            if(playerController!=null)
            {
                playerController.enabled = !playerController.enabled;
            }
        }
    }
}