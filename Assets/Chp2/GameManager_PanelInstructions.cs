using UnityEngine;
using System.Collections;
namespace Chp2{
	public class GameManager_PanelInstructions : MonoBehaviour {
        
        public GameObject panelInstructions;
        public GameManager_Master gameManagerMaster;

		void OnEnable()
		{
            SetInit();
            gameManagerMaster.GameOverEvent += TurnOffPanelInstructions;
		}
		void OnDisable()
		{
            gameManagerMaster.GameOverEvent -= TurnOffPanelInstructions;			
		}
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void SetInit()
		{
            gameManagerMaster = GetComponent<GameManager_Master>();
		}
        void TurnOffPanelInstructions()
        {
            if (panelInstructions != null)
            {
                panelInstructions.SetActive(false);
            }
        }
	}
}