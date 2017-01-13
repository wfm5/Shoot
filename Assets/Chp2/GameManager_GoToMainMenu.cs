using UnityEngine;
using System.Collections;
namespace Chp2{
public class GameManager_GoToMainMenu : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

    void OnEnable(){
        SetInit();
        gameManagerMaster.GoToMenuSceneEvent += GoToMenuScreen;
    }
    void OnDisable(){
        gameManagerMaster.GoToMenuSceneEvent -= GoToMenuScreen;
    }
    void SetInit(){
        gameManagerMaster = GetComponent<GameManager_Master>();
    }
    void GoToMenuScreen(){
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
}