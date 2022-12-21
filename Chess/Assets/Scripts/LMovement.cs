
using UnityEngine;

public class LMovement : MovementStyle
{
    public override bool IsMovementAllowed(int posX, int posY) {
        //L movement logic (normally used by knights in chess)
        if (posX == base.Piece.PosX + 1 || posX == base.Piece.PosX - 1) { //if I moved one space horizontally
            if (posY == base.Piece.PosY + 2 || posY == base.Piece.PosY - 2) { //and I moved two spaces vertically
                return true;
            }
        }
        else if (posY == base.Piece.PosY + 1 || posY == base.Piece.PosY - 1) { //if I moved one space vertically
            if (posX == base.Piece.PosX + 2 || posX == base.Piece.PosX - 2) { //and I moved two spaces horizontally
                return true;
            }
        }
        return false;
    }
}
