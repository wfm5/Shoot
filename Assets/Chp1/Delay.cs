using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 

public class Delay : MonoBehaviour {
    
    public string myMessage = "Hoi";
    public Text textWelcome;
    public GameObject canvasWelcome;

	// Use this for initialization
	void Start () {
        SetInitReferences();
        MyWelcomeMessage();
	}

    void SetInitReferences(){
        textWelcome = GameObject.Find("Text").GetComponent<Text>();
    }
	
    void MyWelcomeMessage(){
        if(textWelcome != null){
            textWelcome.text = myMessage;
        }
        else
        {
            Debug.LogWarning("welcometext not assigned");
        }
        StartCoroutine(DisableCanvas(3.5f));
    }
    

    IEnumerator DisableCanvas(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canvasWelcome.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
