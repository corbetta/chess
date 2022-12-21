using UnityEngine;

public abstract class MovementStyle : MonoBehaviour
{
    public abstract bool IsMovementAllowed(int posX, int posY);
}
