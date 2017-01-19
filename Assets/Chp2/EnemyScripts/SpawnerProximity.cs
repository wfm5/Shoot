using UnityEngine;
using System.Collections; 
namespace Chp2{ 

	public class SpawnerProximity : MonoBehaviour {

        public GameObject ObjectToSpawn;
        public int numberToSpawn;
        public float proximity;
        private float checkRate;
        private float nextCheck;
        public Transform myTransform;
        public Transform playerTransform;
        private Vector3 spawnerPosition;
        				
		// Use this for initialization
		void Start () {
            SetInit();
		}
		
		void SetInit()
		{
            myTransform = transform;
            playerTransform = GameManager_References._player.transform;
            checkRate = Random.Range(0.8f, 1.2f);
		}

		// Update is called once per frame
		void Update () {
		    CheckDistance();
		}

        void CheckDistance()
        {
            if(Time.time > nextCheck){
                nextCheck = Time.time+checkRate;
                if(Vector3.Distance(myTransform.position,playerTransform.position)<proximity)
                {
                    SpawnObjects();
                    this.enabled = false;
                }
            }
        }
        void SpawnObjects()
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                spawnerPosition = myTransform.position + (Vector3)Random.insideUnitSphere * 5;
                Instantiate(ObjectToSpawn, spawnerPosition, myTransform.rotation);
            }
        }
	}
}
