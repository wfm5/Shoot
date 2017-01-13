using UnityEngine;
using System.Collections;
namespace Chp2
{
    public class GameManager_ToggleMenu : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        public GameObject menu;

        // Use this for initialization
        void Start()
        {
            ToggleMenu();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForMenuToggleRequest();
        }

        void OnEnable()
        {
            SetInit();
            gameManagerMaster.GameOverEvent += ToggleMenu;
        }
        void OnDisable()
        {
            gameManagerMaster.GameOverEvent -= ToggleMenu;
        }

        void SetInit()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }
        void CheckForMenuToggleRequest()
        {
            if(Input.GetKeyUp(KeyCode.Escape)&& !gameManagerMaster.isGameOver && !gameManagerMaster.isInventoryUIOn){
                ToggleMenu();
            }
        }
        void ToggleMenu()
        {
            if(menu != null)
            {
                menu.SetActive(!menu.activeSelf);
                gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
                gameManagerMaster.CallMenuToggleEvent();
            }
            else
            {
                Debug.Log("Need to Assign a UI GameObject to ToggleMenu Script in inspector");
            }
        }
    }
}