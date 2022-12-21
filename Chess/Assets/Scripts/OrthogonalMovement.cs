using UnityEngine;

public class OrthogonalMovement : MovementStyle
{
    [SerializeField] private int maxDistance;

    public override bool IsMovementAllowed(int posX, int posY) {
        //orthogonal movement logic
        //horizontal movement
        if (posX == Piece.PosX && Mathf.Abs(posY - Piece.PosY) <= maxDistance) { //piece didn't move farther than maxDistance
            return true;
        }
        //vertical movement
        else if (posY == Piece.PosY && Mathf.Abs(posX - Piece.PosX) <= maxDistance) { //piece didn't move farther than maxDistance
            return true;
        }

        return false;
    }
}
