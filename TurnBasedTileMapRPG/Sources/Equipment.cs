using Data;

namespace TurnBasedTileMapRPG
{
    public class Equipment
    {
        public readonly string Name;
        public readonly Attributes Attributes;
        public readonly ESlotType SlotType;
     
        public Equipment(BaseEquipment baseEquipment)
        {
            Name = baseEquipment.Name;
            Attributes = new Attributes(baseEquipment.Attributes);
            SlotType = baseEquipment.SlotType;
        }   
    }
}
