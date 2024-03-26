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
                    transform.Find("BikeDummyModel").gameObject.SetActive(true);
                    break;
                case SpawnerType.Jeep:
                    name += "Jeep";
                    transform.Find("JeepDummyModel").gameObject.SetActive(true);
                    break;
                case SpawnerType.Hover:
                    name += "Hover";
                    transform.Find("HoverDummyModel").gameObject.SetActive(true);
                    break;
                case SpawnerType.Glider:
                    name += "Glider";
                    transform.Find("GliderDummyModel").gameObject.SetActive(true);
                    break;
            }

            gameObject.name = name;
        }

        private void DisableAll()
        {
            transform.Find("BikeDummyModel").gameObject.tag = "EditorOnly";
            transform.Find("JeepDummyModel").gameObject.tag = "EditorOnly";
            transform.Find("HoverDummyModel").gameObject.tag = "EditorOnly";
            transform.Find("GliderDummyModel").gameObject.tag = "EditorOnly";

            transform.Find("BikeDummyModel").gameObject.SetActive(false);
            transform.Find("JeepDummyModel").gameObject.SetActive(false);
            transform.Find("HoverDummyModel").gameObject.SetActive(false);
            transform.Find("GliderDummyModel").gameObject.SetActive(false);
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
