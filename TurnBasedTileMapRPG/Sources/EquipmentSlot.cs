using Data;

namespace TurnBasedTileMapRPG
{
    public class EquipmentSlot
    {
        public readonly ESlotType SlotType;
        protected Equipment equipment;
        public Equipment Equipment { get { return equipment; } }
        public bool IsFilled { get { return equipment != null; } }

        public EquipmentSlot(ESlotType slotType, Equipment equipment = null)
        {
            SlotType = slotType;
            this.equipment = equipment;
        }

        /// <summary>
        /// Exchanges the current equipment with the new equipment.
        /// </summary>
        /// <param name="newEquipment">The new equipment which will fill this slot</param>
        /// <returns>The old equipment that was in this slot</returns>
        public Equipment ChangeEquipment(Equipment newEquipment = null)
        {
            if (IsFilled)
            {
                var oldEquipment = equipment;
                equipment = newEquipment;
                return oldEquipment;
            } else
            {
                equipment = newEquipment;
                return null;
            }
        }
    }
}
