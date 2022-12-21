using UnityEngine;

public class OrthogonalMovement : MovementStyle
{
    [SerializeField] private int maxDistance;

    public override bool IsMovementAllowed(int posX, int posY) {
        //orthogonal movement logic
        //horizontal movement
        if (posX == Piece.PosX && Mathf.Abs(posY - Piece.PosY) <= maxDistance) { //moving horizontally and piece didn't move farther than maxDistance
            
            //check if there are pieces blocking my route
            if (posY > Piece.PosY) {
                for (int y = Piece.PosY + 1; y < posY; y++) {
                    if (GameManager.PieceAtThisPosition(Piece.PosX, y)){
                        return false;
                    }
                }
            }
            else if (posY < Piece.PosY) {
                for (int y = Piece.PosY - 1; y > posY; y--) {
                    if (GameManager.PieceAtThisPosition(Piece.PosX, y)) {
                        return false;
                    }
                }
            }

            //if no pieces are blocking my route, then I can move here
            return true;
        }
        //vertical movement
        else if (posY == Piece.PosY && Mathf.Abs(posX - Piece.PosX) <= maxDistance) { //moving vertically and piece didn't move farther than maxDistance

            //check if there are pieces blocking my route
            if (posX > Piece.PosX) {
                for (int x = Piece.PosX + 1; x < posX; x++) {
                    if (GameManager.PieceAtThisPosition(x, Piece.PosY)) {
                        return false;
                    }
                }
            }
            else if (posX < Piece.PosX) {
                for (int x = Piece.PosX - 1; x > posX; x--) {
                    if (GameManager.PieceAtThisPosition(x, Piece.PosY)) {
                        return false;
                    }
                }
            }

            //if no pieces are blocking my route, then I can move here
            return true;
        }

        return false;
    }
}
