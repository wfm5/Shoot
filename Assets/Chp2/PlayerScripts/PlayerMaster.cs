using UnityEngine;
using System.Collections;
namespace Chp2{
	public class PlayerMaster : MonoBehaviour {

        //public delegate void GeneralEventHandler();
        //public event GeneralEventHandler EventInventoryChanged;
        //public event GeneralEventHandler EventHandsEmpty;
        //public event GeneralEventHandler EventAmmoChanged;

        //public delegate void AmmoPickupEventHandler(string AmmoName, int quantity);

        public delegate void PlayerHealthEventHandler(int healthchange);
        public event PlayerHealthEventHandler EventPlayerHealthDeduction;
        public event PlayerHealthEventHandler EventPlayerHealthIncrease;

        public void CallEventPlayerHealthDeduction(int dmg)
        {
            if(EventPlayerHealthDeduction!= null)
            {
                EventPlayerHealthDeduction(dmg);
            }
        }
        public void CallEventPlayerHealthIncrease(int dmg)
        {
            if (EventPlayerHealthIncrease!=null)
            {
                EventPlayerHealthIncrease(dmg);
            }
        }
	}
}