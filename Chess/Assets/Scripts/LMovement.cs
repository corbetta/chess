
using UnityEngine;

public class LMovement : MovementStyle
{
    public override bool IsMovementAllowed(int posX, int posY) {
        //L movement logic (normally used by knights in chess)
        if (posX == Piece.PosX + 1 || posX == Piece.PosX - 1) { //if I moved one space horizontally
            if (posY == Piece.PosY + 2 || posY == Piece.PosY - 2) { //and I moved two spaces vertically
                return true;
            }
        }
        else if (posY == Piece.PosY + 1 || posY == Piece.PosY - 1) { //if I moved one space vertically
            if (posX == Piece.PosX + 2 || posX == Piece.PosX - 2) { //and I moved two spaces horizontally
                return true;
            }
        }
        return false;
    }
}
