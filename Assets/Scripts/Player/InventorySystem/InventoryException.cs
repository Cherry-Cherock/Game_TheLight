using System;
namespace Player.InventorySystem
{
    public enum ErrorAction
    {
        Add,
        Remove
    }
    public class InventoryException : Exception
    {
        public ErrorAction Operation { get; }

            public InventoryException(ErrorAction operation, string msg) : base($"{operation} Error: {msg}")
            {
                Operation = operation;
            }
    }
    
}
