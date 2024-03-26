using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Reflection;

namespace StageExtensions
{
    public class StatModifier : MonoBehaviour
    {
        [Header("Won't Affect Most Custom Characters With Custom Code")]
        [Header("Set To '-1' To Leave Value At Default")]
        public Character character;

        [Header("Ground Movement")]
        public float runSpeed = -1;
        public float runAcceleration = -1;
        public float walkSpeed = -1;
        public float brakeAcceleration = -1;
        public float rotationSpeed = -1;

        [Header("Other Movement")]
        public float jumpForce = -1;
        public float minJumpTime = -1;
        public float grindSpeed = -1;
        public float grindAccerleration = -1;
        public float speedShoeSpeed = -1;
        public float speedShoeAcceleration = -1;

        [Header("Other General")]
        public float damageSpeed = -1;
        public float damageTime = -1;

        [Header("Sonic/Shadow/Tails/Amy")]
        public float gaugeMax = -1;

        [Header("Sonic/Shadow/Blaze")]
        public float homingSpeed = -1;
        public float homingTime = -1;
        public float homingDamage = -1;
        public float homingPower = -1;

        [Header("Sonic/Shadow")]
        public float homingTimeE3 = -1;
        public float spindashSpeed = -1;
        public float lightdashSpeed = -1;

        [Header("Sonic/Tails/Omega")]
        public float gaugeHeal = -1;
        public float gaugeHealDelay = -1;

        [Header("Shadow/Amy")]
        public float gaugeHealWait = -1;

        [Header("Knuckles/Rouge/Tails")]
        public float flightAcceleration = -1;
        public float flightSpeedMax = -1;

        [Header("Knuckles/Rouge")]
        public float climbSpeed = -1;
        public float flightSpeedMin = -1;

        [Header("Tails")]
        public float flightTimer = -1;
        public float flightTimerB = -1;

        [Header("Amy")]
        public float stealthLimit = -1;

        [Header("Blaze")]
        public float spinningClawMin = -1;
        public float spinningClawMax = -1;

        [Header("Omega")]
        public int ammoMax = -1;
        public float hover = -1;
        public float laserTime = -1;
        public int laserDamage = -1;
        public float laserPower = -1;
        public float laserSpeed = -1;
        public float launcherTime = -1;
        public int launcherDamage = -1;
        public float launcherPower = -1;
        public float launcherSpeed = -1;
        public float reloadLauncher = -1;
        public int shotDamage = -1;
        public float shotPower = -1;

        public enum Character
        {
            Amy,
            Blaze,
            Knuckles,
            Omega,
            Princess,
            Rouge,
            Shadow,
            Silver,
            Snowboard,
            Sonic_Fast,
            Sonic,
            Tails,
            Vehicle_Bike,
            Vehicle_Glider,
            Vehicle_Hover,
            Vehicle_Jeep
        }

        internal void OnTriggerEnter(Collider other)
        {
            Assembly assembly = typeof(PlayerBase).Assembly;
            Type t;

            switch (character)
            {
                case Character.Amy:
                    t = assembly.GetType("STHLua.Amy_Lua");
                    break;
                case Character.Blaze:
                    t = assembly.GetType("STHLua.Blaze_Lua");
                    break;
                case Character.Knuckles:
                    t = assembly.GetType("STHLua.Knuckles_Lua");
                    break;
                case Character.Omega:
                    t = assembly.GetType("STHLua.Omega_Lua");
                    Omega(t);
                    break;
                case Character.Princess:
                    t = assembly.GetType("STHLua.Princess_Lua");
                    break;
                case Character.Rouge:
                    t = assembly.GetType("STHLua.Rouge_Lua");
                    break;
                case Character.Shadow:
                    t = assembly.GetType("STHLua.Shadow_Lua");
                    break;
                case Character.Silver:
                    t = assembly.GetType("STHLua.Silver_Lua");
                    break;
                case Character.Snowboard:
                    t = assembly.GetType("STHLua.Snow_Board_Lua");
                    break;
                case Character.Sonic_Fast:
                    t = assembly.GetType("STHLua.Sonic_Fast_Lua");
                    break;
                case Character.Sonic:
                    t = assembly.GetType("STHLua.Sonic_New_Lua");
                    break;
                case Character.Tails:
                    t = assembly.GetType("STHLua.Tails_Lua");
                    break;
                case Character.Vehicle_Bike:
                    t = assembly.GetType("STHLua.Vehicle_Param_Bike_Lua");
                    break;
                case Character.Vehicle_Glider:
                    t = assembly.GetType("STHLua.Vehicle_Param_Glider_Lua");
                    break;
                case Character.Vehicle_Hover:
                    t = assembly.GetType("STHLua.Vehicle_Param_Hover_Lua");
                    break;
                case Character.Vehicle_Jeep:
                    t = assembly.GetType("STHLua.Vehicle_Param_Jeep_Lua");
                    break;
            }
        }

        private void Omega(Type t)
        {
            FieldInfo field = t.GetField("c_omega_shot_power", BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.SetField);
            field.SetValue(null, shotPower);
        }
    }
}
