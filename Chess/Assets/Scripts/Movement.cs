using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Orthogonal, DiagonalForward, Diagonal, Forward, ForwardTwoFirstMove, LShape }

    private List<MovementStyle> movementStyles = new List<MovementStyle>();
    private GameManager gameManager;
    private Piece piece;

    void Start() {
        GetComponents<MovementStyle>(movementStyles);
        gameManager = FindObjectOfType<GameManager>();
        piece = GetComponent<Piece>();
    }

    public bool CanIMoveHere(int posX, int posY) {
        //if this movement didn't change my position, return false
        if (posX == piece.PosX && posY == piece.PosY) return false;

        //if this movement would move me out of the board, return false
        if (posX < 0 || posX > 7 || posY < 0 || posY > 7) return false;

        //if any of the movementStyles this piece holds allows it to move to this position, then we can move there
        bool movementCleared = false;
        foreach (MovementStyle ms in movementStyles) {
            if (ms.IsMovementAllowed(posX, posY)) {
                movementCleared = true;
                break; //once any movementStyle allows me to move here, we don't need to check the other movementStyles anymore
            }
        }

        //if a movementStyle has allowed me to move here, then check for pieces in this space 
        if (movementCleared) {
            Piece blockingPiece = gameManager.PieceAtThisPosition(posX, posY);
            if (blockingPiece == null || !blockingPiece.Alive) {
                return true; //if this space is empty, I can move there!
            }
            else if (blockingPiece.Team == piece.Team) {
                return false; //if this space is occupied by my teammate, I cannot move there
            }
            else { //if this space is occupied by an opponnent, capture the piece and I can move there
                blockingPiece.Captured();
                return true;
            }
        }
        return false;
    }
}
