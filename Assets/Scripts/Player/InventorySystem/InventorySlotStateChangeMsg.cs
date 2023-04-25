
namespace Player.InventorySystem
{
    public class InventorySlotStateChangeMsg
    {
        public ItemStack NewState { get; }
        
        public bool Active { get; }

        public InventorySlotStateChangeMsg(ItemStack newState, bool active)
        {
            NewState = newState;
            Active = active;
        }
    }
}