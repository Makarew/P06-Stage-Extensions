using UnityEngine;

namespace StageExtensions
{
    public class CounterCutscene : MonoBehaviour
    {
        public int requiredAmount;
        [HideInInspector]
        public int amount;

        private Collider player;
        
        public Cutscene origTrigger;
        public GameObject[] objectToggle;

        public SwitchCutscene switchTrigger;
        public bool useSwitchEnter = true;
        public bool useSwitchExit;

        private void Update()
        {
            if(player == null && FindObjectOfType<PlayerBase>())
            {
                player = FindObjectOfType<PlayerBase>().GetComponent<Collider>();
            }

            if(amount == requiredAmount)
            {
                amount = 0;
                if(objectToggle != null && objectToggle.Length > 0)
                {
                    for(int i = 0; i < objectToggle.Length; i++)
                    {
                        objectToggle[i].SetActive(!objectToggle[i].activeSelf);
                    }
                }
                if (origTrigger != null)
                {
                    origTrigger.OnTriggerEnter(player);
                }
                if(switchTrigger != null)
                {
                    if (useSwitchEnter)
                        switchTrigger.TriggerOn();
                    if (useSwitchExit)
                        switchTrigger.TriggerOff();
                }
            }
        }
    }
}
