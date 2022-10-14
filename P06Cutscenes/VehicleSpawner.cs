using UnityEngine;
using System;
using System.Reflection;

namespace StageExtensions
{
    public class VehicleSpawner : MonoBehaviour
    {
        public enum SpawnerType
        {
            Bike,
            Jeep,
            Hover,
            Glider
        }

        public SpawnerType type;
        public bool canShoot = true;
        public bool canExit = true;

        [HideInInspector]
        internal UnityEngine.Object item;
        [HideInInspector]
        public GameObject[] VehicleReferences;

        private void OnValidate()
        {
            string name = "VehicleSpawner";
            DisableAll();
            switch (type)
            {
                case SpawnerType.Bike:
                    name += "Bike";
                    VehicleReferences[0].SetActive(true);
                    break;
                case SpawnerType.Jeep:
                    name += "Jeep";
                    VehicleReferences[1].SetActive(true);
                    break;
                case SpawnerType.Hover:
                    name += "Hover";
                    VehicleReferences[2].SetActive(true);
                    break;
                case SpawnerType.Glider:
                    name += "Glider";
                    VehicleReferences[3].SetActive(true);
                    break;
            }

            gameObject.name = name;
        }

        private void DisableAll()
        {
            for (int i = 0; i < VehicleReferences.Length; i++)
            {
                VehicleReferences[i].tag = "EditorOnly";
                VehicleReferences[i].SetActive(false);
            }
        }

        private void Start()
        {
            UnityEngine.Object.Instantiate(item, transform);
            VehicleBase vbase = GetComponentInChildren<VehicleBase>();
            Type t = vbase.GetType();
            if (canShoot)
            {
                FieldInfo field = t.GetField("IsShoot", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.GetField);
                field.SetValue(vbase, true);
            }
            if (canExit)
            {
                FieldInfo field = t.GetField("IsGetOut", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.GetField);
                field.SetValue(vbase, true);
            }
        }
    }
}
