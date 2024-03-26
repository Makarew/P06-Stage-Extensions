using System;
using UnityEngine;
using System.Reflection;

namespace StageExtensions
{
    public class PsychokinesisObject : MonoBehaviour
    {
        [Header("Remember To Add A Collider")]

        public int throwDamage = 1;

        [Header("Audio")]
        public AudioClip[] hitClip;
        public float volume;
        public bool randomPitch;

        public void Awake()
        {
            Collider col;
            if (!TryGetComponent<Collider>(out col)) gameObject.AddComponent<BoxCollider>();

            GameObject asPre = Instantiate(new GameObject());
            asPre.AddComponent<AudioSource>();

            gameObject.AddComponent<Rigidbody>();

            PhysicsObj physObj = gameObject.AddComponent<PhysicsObj>();

            Type t = physObj.GetType();
            FieldInfo field = t.GetField("PsiThrowDamage", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.GetField);
            field.SetValue(physObj, throwDamage);

            Renderer ren;
            if (TryGetComponent<Renderer>(out ren)) physObj.Renderer = ren;

            ContactObject conObj = gameObject.AddComponent<ContactObject>();

            conObj.Volume = volume;
            conObj.RandomPitch = randomPitch;
            conObj.ContactClip = hitClip;
            conObj.AudioSourcePrefab = asPre;

            gameObject.layer = LayerMask.NameToLayer("BreakableObj");
        }
    }
}
