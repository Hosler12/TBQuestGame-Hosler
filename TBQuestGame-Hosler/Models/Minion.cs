using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame_Hosler.Models
{

    public class Minion : Npc, ISpeak, IBattle
    {
        Random r = new Random();
        public int SkillLevel { get; set; }
        public List<string> Messages { get; set; }
        public BattleModeName BattleMode { get; set; }
        public Weapon CurrentWeapon { get; set; }
        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public Minion()
        {

        }

        public Minion(
            int id,
            string name,
            string description,
            List<string> messages,
            int skillLevel,
            Weapon currentWeapon)
            : base(id, name, description)
        {
            Messages = messages;
            SkillLevel = skillLevel;
            CurrentWeapon = currentWeapon;
        }

        /// <summary>
        /// generate a message or use default
        /// </summary>
        /// <returns>message text</returns>
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns>message text</returns>
        private string GetMessage()
        {
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }

        #region BATTLE METHODS

        public double Attack()
        {
            return SkillLevel;
        }

        public double Cast()
        {
            return SkillLevel / 2;
        }

        #endregion

    }
}
