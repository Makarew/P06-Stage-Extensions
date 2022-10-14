using UnityEngine;

namespace StageExtensions
{
    public class ThornSpawner : MonoBehaviour
    {
        private void Awake()
        {
            UnityEngine.Object.Instantiate(Resources.Load("defaultprefabs/objects/common/HavokThorn"), transform);
        }

        private void OnValidate()
        {
            gameObject.name = "ThornSpawner";
        }
    }
}
