using MelonLoader;
using UnityEngine;
using System.Collections.Generic;
using HarmonyLib;
using P06ML.Metadata;
using System.Reflection;

namespace StageExtensions
{
    public class CutsceneMain : MelonMod
    {
        public UnityEngine.Object Bike;
        public UnityEngine.Object Jeep;
        public UnityEngine.Object Glider;
        public UnityEngine.Object Hover;

        internal bool didLoad;

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
            LoadVehicles();
        }

        private void LoadVehicles()
        {
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

            if (Bike != null)
            {
                didLoad = true;

                HarmonyLib.Harmony harmony = new HarmonyLib.Harmony("StageExtenstions");
                MethodInfo smLoad = AccessTools.Method(typeof(StageMetadata), "Load");
                MethodInfo smLoadPatch = AccessTools.Method(typeof(CutsceneMain), nameof(CutsceneMain.StageMetadataPatch));

                harmony.Patch(smLoad, null, new HarmonyMethod(smLoadPatch));
            }
        }

        public override void OnDeinitializeMelon()
        {
            base.OnDeinitializeMelon();
            Bike = null;
            Jeep = null;
            Glider = null;
            Hover = null;
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

            if (sceneName == "Disclaimer" && !didLoad)
            {
                LoadVehicles();
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

            public static void StageMetadataPatch(ref StageMetadata __result, string path)
            {
                StageMetadataNew smn = StageMetadataNew.Load(path);

                if (smn.RequireStageExtensions == StageMetadataNew.RequireSE.Not_Required) return;

                __result.Description = smn.DescriptionSE;
                __result.AssetBundle = __result.Location + "\\" + smn.AssetBundleSE;
                __result.Title = smn.TitleSE;
            }
    }
}
