using UnityEngine;

public class OrthogonalMovement : MovementStyle
{
    [SerializeField] private int maxDistance;
    
    public override bool IsMovementAllowed(int posX, int posY) {
        //orthogonal movement logic
        

        return false;
    }

}
