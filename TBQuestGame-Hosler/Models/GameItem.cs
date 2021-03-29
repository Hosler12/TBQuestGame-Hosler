using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame_Hosler.Models
{
    public class GameItem
    {
        //
        // auto implemented properties are used for 
        //
        public int Id { get; set; }
        public string Name { get; set; }
        public int Bonus { get; set; }
        public string Description { get; set; }
        public string UseMessage { get; set; }

        public string Information
        {
            get
            {
                return InformationString();
            }
        }

        public GameItem(int id, string name, int bonus, string description, string useMessage = "")
        {
            Id = id;
            Name = name;
            Bonus = bonus;
            Description = description;
            UseMessage = useMessage;
        }

        public virtual string InformationString()
        {
            return $"{Name}: {Description}/nValue: {Bonus}";
        }
    }
}
