using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Chp2{
	public class PlayerHealth : MonoBehaviour {

        private GameManager_Master gameManagerMaster;
        private PlayerMaster playerMaster;
        public int playerhealth;
        public Text healthText;

		void OnEnable()
		{
            SetInit();
            SetUI();
            playerMaster.EventPlayerHealthDeduction += DeductHealth;
            playerMaster.EventPlayerHealthIncrease += IncreaseHealth;

		}
		void OnDisable()
		{
            playerMaster.EventPlayerHealthDeduction -= DeductHealth;
            playerMaster.EventPlayerHealthIncrease -= IncreaseHealth;


		}
		// Use this for initialization
		void Start () {
           // StartCoroutine(TestHealthDeduction());
		}
		
		// Update is called once per frame
		void Update () {
            Debug.Log(playerhealth);
		}
		void SetInit()
		{
            gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
            playerMaster = GetComponent<PlayerMaster>();
		}
        IEnumerator TestHealthDeduction()
        {
            yield return new WaitForSeconds(4);
            DeductHealth(100);
        }
        void DeductHealth(int healthChange)
        {
            playerhealth -= healthChange;

            if(playerhealth<= 0)
            {
                Debug.Log("loss hp");
                playerhealth = 0;                
                gameManagerMaster.CallGameOverEvent();
            }
        }
        void IncreaseHealth(int healthChange)
        {
            playerhealth += healthChange;
            if(playerhealth>100)
            {
                playerhealth = 100;
            }
        }
        void SetUI()
        {

        }
	}
}