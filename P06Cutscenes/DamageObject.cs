using UnityEngine;

namespace StageExtensions
{
    public class DamageObject : MonoBehaviour
    {
        public enum type
        {
            drain,
            hit
        }

        public type damageType;

        public float ringDrainRate = 5;

        private float tTime;
        private float timer;

        internal PlayerBase player;

        private float rate = 100f;

        private void Start()
        {
            tTime = 1 / ringDrainRate;
        }

        private void Update()
        {
            if (damageType == type.hit && player != null)
            {
                player.OnHurtEnter(0);
            }

            if (damageType == type.drain)
            {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else
                {
                    if (player != null)
                        player.OnBulletHit(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)), rate, 0);
                    timer = tTime;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
               player = other.GetComponent<PlayerBase>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                player = null;
            }
        }
    }
}
