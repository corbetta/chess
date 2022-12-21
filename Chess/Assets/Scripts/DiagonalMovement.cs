using UnityEngine;

public class DiagonalMovement : MovementStyle
{
    [SerializeField] private int maxDistance;

    public override bool IsMovementAllowed(int posX, int posY) {
        //diagonal movement logic
        if (Mathf.Abs(posX - base.Piece.PosX) == Mathf.Abs(posY - base.Piece.PosY)) { //piece is moving the same distance in X and Y
            if (Mathf.Abs(posX - base.Piece.PosX) <= maxDistance) { //piece didn't move farther than maxDistance (don't need to check Y because it's the same as X)
                return true;
            }
        }

        return false;
    }
}