using UnityEngine;

public class PawnMovement : MovementStyle
{
    private int forward;
    private GameManager gameManager;

    void Start() {
        gameManager = GetComponent<GameManager>();    
    }

    public override bool IsMovementAllowed(int posX, int posY) {
        //set forward to go up for white pieces and down for black pieces
        if (base.Piece.Team == TeamColor.White) forward = 1;
        else forward = -1;

        //basic forward movement
        if (posX == base.Piece.PosX) {
            if (gameManager.PieceAtThisPosition(posX, base.Piece.PosY + forward) == null) { //if there is no piece one space in front of this piece
                if (posY == base.Piece.PosY + forward) { //if I tried to move forward one space
                    return true;
                }
                if (gameManager.PieceAtThisPosition(posX, base.Piece.PosY + (forward * 2)) == null) { //if there is no piece two spaces forward from this piece
                    if (posY == base.Piece.PosY + (forward * 2)) { //if I tried to move forward two spaces
                        if (base.Piece.HasMoved == false) { //if I have not moved before (so I can move up twice)
                            return true;
                        }
                    }
                }
            }
        }
        //diagonal movement for taking opponent's pieces
        if (posY == base.Piece.PosY + forward) {
            if (posX == base.Piece.PosX + 1 || posX == base.Piece.PosX - 1) {
                if (gameManager.PieceAtThisPosition(posX, posY).Team != base.Piece.Team) { //if I just moved onto an opponent's piece, move there
                    return true;
                }
            }
        }

        return false;
    }
}
