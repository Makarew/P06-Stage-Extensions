using System.Collections.Generic;
using UnityEngine;

namespace StageExtensions
{
    public class SwitchCutscene : MonoBehaviour
    {
        public string listenTag = "Player";

        public bool useTriggerEnter = true;
        public bool useTriggerExit;
        public bool triggerEnterOneTime;
        public bool triggerExitOneTime;

        public bool toggleOnExit;

        public GameObject[] objectToggle;

        public CounterCutscene counter;

        [Header("Cutscene Playables")]
        public Animator[] enterAnimators;
        public Animator[] exitAnimators;

        public AudioClip[] enterSounds;
        public AudioClip[] exitSounds;
        private List<AudioSource> enterSources;
        private List<AudioSource> exitSources;

        private int enTimer;
        private int exTimer;

        private void Start()
        {
            if (enterAnimators == null)
                enterAnimators = new Animator[0];
            if (exitAnimators == null)
                exitAnimators = new Animator[0];
            if (enterSounds == null)
                enterSounds = new AudioClip[0];
            if (exitSounds == null)
                exitSounds = new AudioClip[0];
            if (objectToggle == null)
                objectToggle = new GameObject[0];

            enterSources = new List<AudioSource>();
            for (int i = 0; i < enterSounds.Length; i++)
            {
                enterSources.Add(Instantiate(new GameObject(), transform).AddComponent<AudioSource>());
                enterSources[i].clip = enterSounds[i];
                enterSources[i].playOnAwake = false;
                enterSources[i].loop = false;
                enterSources[i].Stop();
            }

            exitSources = new List<AudioSource>();
            for (int i = 0; i < exitSounds.Length; i++)
            {
                exitSources.Add(Instantiate(new GameObject(), transform).AddComponent<AudioSource>());
                exitSources[i].clip = exitSounds[i];
                exitSources[i].playOnAwake = false;
                exitSources[i].loop = false;
                exitSources[i].Stop();
            }
        }

        private void Update()
        {
            if (enTimer > 0)
            {
                enTimer--;
            }
            else if (enTimer == 0)
            {
                for (int i = 0; i < enterAnimators.Length; i++)
                {
                    enterAnimators[i].SetBool("start", false);
                }
                enTimer = -1;
            }

            if (exTimer > 0)
            {
                exTimer--;
            }
            else if (exTimer == 0)
            {
                for (int i = 0; i < exitAnimators.Length; i++)
                {
                    exitAnimators[i].SetBool("start", false);
                }
                exTimer = -1;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == listenTag && useTriggerEnter)
            {
                TriggerOn();
            }
        }

        internal void TriggerOn()
        {
            for (int i = 0; i < enterAnimators.Length; i++)
            {
                enterAnimators[i].SetBool("start", true);
            }

            for (int i = 0; i < enterSources.Count; i++)
            {
                if (enterSources[i].isPlaying)
                    enterSources[i].Stop();
                enterSources[i].Play();
            }

            if (triggerEnterOneTime)
                useTriggerEnter = false;

            enTimer = 2;

            if (!toggleOnExit && objectToggle.Length > 0) { 
                for (int i = 0; i < objectToggle.Length; i++)
                {
                    objectToggle[i].SetActive(!objectToggle[i].activeSelf);
                }
            }

            if (counter == null) return;
            counter.amount += 1;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == listenTag && useTriggerExit)
            {
                TriggerOff();
            }
        }

        internal void TriggerOff()
        {
            for (int i = 0; i < exitAnimators.Length; i++)
            {
                exitAnimators[i].SetBool("start", true);
            }

            for (int i = 0; i < exitSources.Count; i++)
            {
                if (exitSources[i].isPlaying)
                    exitSources[i].Stop();
                exitSources[i].Play();
            }

            if (triggerExitOneTime)
                useTriggerExit = false;

            exTimer = 2;

            if (toggleOnExit && objectToggle.Length > 0)
            {
                for (int i = 0; i < objectToggle.Length; i++)
                {
                    objectToggle[i].SetActive(!objectToggle[i].activeSelf);
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (gameObject.GetComponent<BoxCollider>())
            {
                Gizmos.color = new Color(0, 0.8f, 0.8f, 0.3f);
                Gizmos.DrawCube(transform.position + gameObject.GetComponent<BoxCollider>().center, gameObject.GetComponent<BoxCollider>().size);
            }
            if (gameObject.GetComponent<SphereCollider>())
            {
                Gizmos.color = new Color(0, 0.8f, 0.8f, 0.3f);
                Gizmos.DrawSphere(transform.position + gameObject.GetComponent<SphereCollider>().center, gameObject.GetComponent<SphereCollider>().radius);
            }
        }
    }
}
