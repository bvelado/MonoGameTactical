using System;
using Data;

namespace TurnBasedTileMapRPG
{
    public class Attributes
    {
        public int HP { get; private set; }
        public int Atk { get; private set; }

        private Attributes(Attributes attributes)
        {
            HP = attributes.HP;
            Atk = attributes.Atk;
        }

        public Attributes()
        {
            HP = 0;
            Atk = 0;
        }

        public Attributes(BaseAttributes baseAttributes)
        {
            HP = baseAttributes.HP;
            Atk = baseAttributes.Atk;
        }

        public override string ToString()
        {
            return string.Format("HP : {0}\r\nAtk : {1}", HP, Atk);
        }

        public static Attributes operator +(Attributes a1, Attributes a2)
        {
            var result = new Attributes(a1);

            result.HP += a2.HP;
            result.Atk += a2.Atk;

            return result;
        }
    }
}
