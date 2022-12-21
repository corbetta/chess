using UnityEngine;

public class OrthogonalMovement : MovementStyle
{
    [SerializeField] private int maxDistance;

    public override bool IsMovementAllowed(int posX, int posY) {
        //orthogonal movement logic
        //horizontal movement
        if (posX == base.Piece.PosX) {
            if (Mathf.Abs(posY - base.Piece.PosY) <= maxDistance) { //piece didn't move farther than maxDistance
                return true;
            }
        }
        //vertical movement
        else if (posY == base.Piece.PosY) {
            if (Mathf.Abs(posX - base.Piece.PosX) <= maxDistance) { //piece didn't move farther than maxDistance
                return true;
            }
        }

        return false;
    }
}
