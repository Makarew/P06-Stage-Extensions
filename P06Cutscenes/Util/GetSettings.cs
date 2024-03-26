using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageExtensions.Util
{
    public static class GetSettings
    {
        public static int TextureQuality()
        {
            return Singleton<Settings>.Instance.settings.TextureQuality;
        }

        public static bool Bloom()
        {
            if (Singleton<Settings>.Instance.settings.Bloom == 0) return false;
            else return true;
        }

        public static bool Cutscenes()
        {
            if (Singleton<Settings>.Instance.settings.Cutscenes == 0) return false;
            else return true;
        }

        public static bool JiggleBones()
        {
            if (Singleton<Settings>.Instance.settings.JiggleBones == 0) return false;
            else return true;
        }

        public static float MusicVolume()
        {
            return Singleton<Settings>.Instance.settings.MusicVolume;
        }

        public static float SFXVolume()
        {
            return Singleton<Settings>.Instance.settings.SEVolume;
        }

        public static float VoiceVolume()
        {
            return Singleton<Settings>.Instance.settings.VoiceVolume;
        }

        public static int MusicType()
        {
            return Singleton<Settings>.Instance.settings.E3XBLAMusic;
        }
    }
}
