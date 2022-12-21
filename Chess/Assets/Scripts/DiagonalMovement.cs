using UnityEngine;

public class DiagonalMovement : MovementStyle
{
    [SerializeField] private int maxDistance;
    private int distanceToMove;
    private int xDirection;
    private int yDirection;

    public override bool IsMovementAllowed(int posX, int posY) {
        //diagonal movement logic
        if (Mathf.Abs(posX - Piece.PosX) == Mathf.Abs(posY - Piece.PosY)) { //piece is moving the same distance in X and Y
            distanceToMove = Mathf.Abs(posX - Piece.PosX); //distance to move is the same for X and Y, so we only need to get this value for one of them
            if (distanceToMove <= maxDistance) { //piece didn't move farther than maxDistance

                if (posX > Piece.PosX) xDirection = 1;
                else xDirection = -1;

                if (posY > Piece.PosY) yDirection = 1;
                else yDirection = -1;

                //check if there are piece blocking my route
                for (int i = 0; i < distanceToMove; i++) {
                    int nextPosX = Piece.PosX + (xDirection * i);
                    int nextPosY = Piece.PosY + (yDirection * i);
                    if (GameManager.PieceAtThisPosition(nextPosX, nextPosY)) {
                        return false;
                    }
                }

                //if no pieces are blocking my route, then I can move here
                return true;
            }
        }

        return false;
    }
}