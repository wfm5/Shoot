using UnityEngine;
using System.Collections;
namespace Chp2
{
    public class GameManager_TogglePause : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        private bool isPaused;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }
        void OnEnable()
        {
            SetInit();
            gameManagerMaster.MenuToggleEvent += TogglePause;
            gameManagerMaster.InventoryUIToggleEvent += TogglePause;
        }
        void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= TogglePause;
        }
        void SetInit()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }
        void TogglePause()
        {
            if(isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }
}