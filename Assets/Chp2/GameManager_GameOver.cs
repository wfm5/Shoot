using UnityEngine;
using System.Collections;
namespace Chp2
{
    public class GameManager_GameOver : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        public GameObject panelGameOver;

        void OnEnable()
        {
            SetInit();
            gameManagerMaster.GameOverEvent += TurnOnGameOverPanel;
        }
        void OnDisable()
        {
            gameManagerMaster.GameOverEvent -= TurnOnGameOverPanel;
        }
        void SetInit()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }
        void TurnOnGameOverPanel()
        {            
            if(panelGameOver!= null)
            {                
                panelGameOver.SetActive(true);
            }
        }        
    }
}