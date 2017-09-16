using Data;

namespace TurnBasedTileMapRPG {

    public class Inventory
    {
        protected EquipmentSlot[] equipmentSlots; 

        public Inventory(ESlotType[] slotTypes)
        {
            equipmentSlots = new EquipmentSlot[slotTypes.Length];
            for(int i = 0; i < slotTypes.Length; i++)
            {
                equipmentSlots[i] = new EquipmentSlot(slotTypes[i]);
            }
        }

        public bool HasSlot(ESlotType slotType)
        {
            for(int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].SlotType == slotType)
                    return true;
            }
            return false;
        }

        public bool HasEquipmentAt(ESlotType slotType)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].SlotType == slotType && equipmentSlots[i].IsFilled)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Use HasSlot before to ensure this function does 
        /// not return null because the slot does not exist
        /// </summary>
        /// <param name="slotType"></param>
        /// <returns>
        /// The equipment in this slot. 
        /// Null if no equipment equiped.
        /// </returns>
        public Equipment GetEquipmentAt(ESlotType slotType)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].SlotType == slotType)
                    return equipmentSlots[i].Equipment;
            }

            // Shouldn't reach here if tested with HasSlot
            return null;
        }

        /// <summary>
        /// Exchanges the old equipment at this slot with the new equipment
        /// </summary>
        /// <param name="slotType">The slot where to perform the change</param>
        /// <param name="newEquipment">The new equipment</param>
        /// <returns>The old equipment if there was one</returns>
        public Equipment SetEquipmentAt(ESlotType slotType, Equipment newEquipment = null)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].SlotType == slotType)
                    return equipmentSlots[i].ChangeEquipment(newEquipment);
            }

            // Shouldn't reach here if tested with HasSlot
            return null;
        }

        public Attributes GetAttributesSum()
        {
            Attributes result = new Attributes();
            foreach(var slot in equipmentSlots)
            {
                if (slot.IsFilled)
                    result += slot.Equipment.Attributes;
            }
            return result;
        }
    }
}
