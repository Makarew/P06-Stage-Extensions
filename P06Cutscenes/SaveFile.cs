using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StageExtensions
{
    public class SaveFile : MonoBehaviour
    {
        public bool autoSave;
        public bool saveAnywhere;

        public bool playerPosition = true;
        public bool currentCharacter = true;

        public Transform[] positions;

        public CounterCutscene[] counters;

        public Teleporter[] teleporters;
    }
}
