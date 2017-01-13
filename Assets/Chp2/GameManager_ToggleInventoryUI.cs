using UnityEngine;
using System.Collections;
namespace Chp2
{
    public class GameManager_ToggleInventoryUI : MonoBehaviour
    {
        [Tooltip("Does this game mode have an inventory?")]
        public bool hasInventory;
        public GameObject inventoryUI;
        public string toggleInventoryButton;
        private GameManager_Master gameManagerMaster;


        // Use this for initialization
        void Start()
        {
            SetInit();
        }
        // Update is called once per frame
        void Update()
        {
            CheckForInventory();
        }        
        void SetInit()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();

            if(toggleInventoryButton=="")
            {
                Debug.LogWarning("Please type in the name of the button used to toggle inventory.");
                this.enabled = false;
            }
        }
        void CheckForInventory()
        {
            if(Input.GetButtonUp(toggleInventoryButton) && !gameManagerMaster.isMenuOn && !gameManagerMaster.isGameOver && hasInventory)
            {
                ToggleInventoryUI();
            }
        }
        void ToggleInventoryUI()
        {
            if (inventoryUI != null)
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                gameManagerMaster.isInventoryUIOn = !gameManagerMaster.isInventoryUIOn;
                gameManagerMaster.CallInventoryUIToggle();
            }
        }
    }
}