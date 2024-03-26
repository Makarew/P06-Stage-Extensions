using UnityEngine;
using UnityEditor;
using Rewired;

namespace StageExtensions
{
    public class Teleporter : MonoBehaviour
    {
        public bool keepMomentum = true;

        public bool reUsable = true;

        private Vector3 tpPoint;
        private bool selected;

        internal void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Vector3 travelPoint = transform.position;

                if (gameObject.GetComponents<Collider>().Length > 1)
                {
                    if (Vector3.Distance(transform.position + gameObject.GetComponents<BoxCollider>()[0].center, other.transform.position) > Vector3.Distance(transform.position + gameObject.GetComponents<BoxCollider>()[1].center, other.transform.position))
                    {
                        travelPoint = transform.position + gameObject.GetComponents<BoxCollider>()[1].center;
                    }
                }

                other.transform.position = travelPoint;

                if (reUsable == false)
                {
                    foreach (Collider col in gameObject.GetComponents<Collider>())
                    {
                        col.enabled = false;
                    }
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            selected = true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawIcon(transform.position, "TPSourceIco", true);

            if (transform.Find("TeleportTarget"))
            {
                if (selected)
                {
                    transform.Find("TeleportTarget").position = tpPoint;
                }

                tpPoint = transform.Find("TeleportTarget").position;
                Gizmos.DrawIcon(tpPoint, "TPEndIco", true);

                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position, tpPoint);

                if (gameObject.GetComponents<BoxCollider>().Length > 1 )
                {
                    gameObject.GetComponents<BoxCollider>()[1].center = transform.Find("TeleportTarget").localPosition;
                    gameObject.GetComponents<BoxCollider>()[1].size = transform.Find("TeleportTarget").GetComponent<BoxCollider>().size;
                }
            }

            selected = false;
        }
    }
}
