namespace Data
{
    public class BaseEquipment
    {
        public string Name;
        public BaseAttributes Attributes;
        public ESlotType SlotType;

        public BaseEquipment()
        {
            Name = "";
            Attributes = new BaseAttributes();
            SlotType = ESlotType.Head;
        }
    }
}
