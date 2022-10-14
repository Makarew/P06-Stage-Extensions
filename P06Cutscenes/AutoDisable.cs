using UnityEngine;

namespace StageExtensions
{
    public class AutoDisable : MonoBehaviour
    {
        private int c = 5;
        internal bool inArea;

        public GameObject target;
        public AudioClip respawnBGM;

        private AudioSource mainSource;

        internal bool triggerEx = true;

        private void Start()
        {
            mainSource = GameObject.Find("Stage").GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (inArea)
            {
                return;
            }

            if (c > 0)
            {
                c--;
            } else if (c == 0)
            {
                c = -1;
                target.SetActive(false);

                DamageObject[] obj = transform.GetComponentsInChildren<DamageObject>();

                for (int i = 0; i < obj.Length; i++)
                {
                    obj[i].player = null;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                inArea = true;
                target.SetActive(true);

                c = 5;

                triggerEx = false;

                if (mainSource.time < 1)
                {
                    mainSource.clip = respawnBGM;
                    mainSource.Play();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                inArea = false;
                triggerEx = true;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player" && triggerEx == true)
            {
                triggerEx = false;
                inArea = true;
            }
        }
    }
}
