using Data;

namespace TurnBasedTileMapRPG
{
    public class HumanCharacter : Character
    {
        protected string name;
        protected Class baseClass;
        protected Inventory inventory;

        public override Attributes Attributes {
            get {
                return baseClass.Attributes + inventory.GetAttributesSum();
            }
        }

        public override string Name {
            get {
                return name;
            }
        }

        public Inventory Inventory {
            get { return inventory; }
        }

        public HumanCharacter(string name, Class baseClass, Inventory inventory = null)
        {
            this.name = name;
            this.baseClass = baseClass;
            if (inventory != null)
                this.inventory = inventory;
            else
                this.inventory = new Inventory(
                    new Data.ESlotType[] { Data.ESlotType.Head, Data.ESlotType.Body, Data.ESlotType.Feet, Data.ESlotType.Ring });
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", name, Attributes.ToString());
        }
    }
}
