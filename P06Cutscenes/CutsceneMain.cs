using MelonLoader;
using UnityEngine;
using System.Collections.Generic;

namespace StageExtensions
{
    public class CutsceneMain : MelonMod
    {
        public UnityEngine.Object Bike;
        public UnityEngine.Object Jeep;
        public UnityEngine.Object Glider;
        public UnityEngine.Object Hover;

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
            UnityEngine.Object[] commonItems = Resources.LoadAll("defaultprefabs/objects");

            for (int i = 0; i < commonItems.Length; i++)
            {
                if (commonItems[i].name == "Bike")
                {
                    Bike = commonItems[i];
                }
                else if (commonItems[i].name == "Jeep")
                {
                    Jeep = commonItems[i];
                }
                else if (commonItems[i].name == "Hover")
                {
                    Hover = commonItems[i];
                }
                else if (commonItems[i].name == "Glider")
                {
                    Glider = commonItems[i];
                }
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);

            VehicleSpawner[] spawners = GameObject.FindObjectsOfType<VehicleSpawner>();
            for (int i = 0; i < spawners.Length; i++)
            {
                switch (spawners[i].type)
                {
                    case VehicleSpawner.SpawnerType.Bike:
                        spawners[i].item = Bike;
                        break;
                    case VehicleSpawner.SpawnerType.Jeep:
                        spawners[i].item = Jeep;
                        break;
                    case VehicleSpawner.SpawnerType.Hover:
                        spawners[i].item = Hover;
                        break;
                    case VehicleSpawner.SpawnerType.Glider:
                        spawners[i].item = Glider;
                        break;
                }
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        internal GameObject[] GetByName(string name)
        {
            GameObject[] spawners = GameObject.FindObjectsOfType<GameObject>();
            List<GameObject> list = new List<GameObject>();
            for (int i = 0; i < spawners.Length; i++)
            {
                if (spawners[i].name.Contains(name))
                    list.Add(spawners[i]);
            }
            return list.ToArray();
        }
    }
}
