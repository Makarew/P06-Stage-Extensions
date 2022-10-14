using UnityEngine;

namespace StageExtensions
{
    public class QuickCharacterSwitch : MonoBehaviour
    {
        public Cutscene.newCharacter character;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                SwitchCharacter(character);
            }
        }

        internal void SwitchCharacter(Cutscene.newCharacter character)
        {
            switch (character)
            {
                case Cutscene.newCharacter.keep:
                    break;
                case Cutscene.newCharacter.sonic_new:
                    ChangeCharacter("sonic_new", 0);
                    break;
                case Cutscene.newCharacter.sonic_fast:
                    ChangeCharacter("sonic_fast", 0);
                    break;
                case Cutscene.newCharacter.snow_board:
                    ChangeCharacter("snow_board", 0);
                    break;
                case Cutscene.newCharacter.princess:
                    ChangeCharacter("princess", 4);
                    break;
                case Cutscene.newCharacter.shadow:
                    ChangeCharacter("shadow", 5);
                    break;
                case Cutscene.newCharacter.silver:
                    ChangeCharacter("silver", 1);
                    break;
                case Cutscene.newCharacter.tails:
                    ChangeCharacter("tails", 2);
                    break;
                case Cutscene.newCharacter.knuckles:
                    ChangeCharacter("knuckles", 3);
                    break;
                case Cutscene.newCharacter.rouge:
                    ChangeCharacter("rouge", 7);
                    break;
                case Cutscene.newCharacter.omega:
                    ChangeCharacter("omega", 6);
                    break;
            }
        }

        private void ChangeCharacter(string name, int id)
        {
            PlayerBase pb = FindObjectOfType<PlayerBase>();

            PlayerBase newchar = (Instantiate(Resources.Load("DefaultPrefabs/Player/" + name), pb.transform.position, pb.transform.rotation) as GameObject).GetComponent<PlayerBase>();
            newchar.SetPlayer(id, name);
            newchar.StartPlayer(false);
            Destroy(pb.gameObject);
        }
    }
}
