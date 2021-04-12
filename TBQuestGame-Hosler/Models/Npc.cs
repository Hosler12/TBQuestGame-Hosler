using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame_Hosler.Models
{
    public abstract class Npc : Character
    {
        public string Description { get; set; }
        public string Information
        {
            get
            {
                return InformationText();
            }
            set
            {

            }
        }

        public Npc()
        {

        }

        public Npc(int id, string name, string description)
            : base(id, name, description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        protected abstract string InformationText();
    }
}
