using UnityEngine;
using System.Collections;
namespace Chp2
{
    public class GameManager_References : MonoBehaviour
    {
        public string playerTag;
        public static string _playerTag;

        public string enemyTag;
        public static string _enemyTag;

        public static GameObject _player;

        void OnEnable()
        {
            if (playerTag == "")
            {
                Debug.LogWarning("Please type in the name of the player tag in game manager references.");
            }
            if (enemyTag == "")
            {
                Debug.LogWarning("Please type in the name of the player tag in game manager references.");
            }

            _playerTag = playerTag;
            _enemyTag = enemyTag;

            _player = GameObject.FindGameObjectWithTag(_playerTag);
        }
        
    }
}