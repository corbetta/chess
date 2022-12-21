using UnityEngine;

public abstract class MovementStyle : MonoBehaviour
{
    private Piece piece;
    public Piece Piece { get { return piece; } }

    void Start() {
        piece = GetComponent<Piece>();
    }
    public abstract bool IsMovementAllowed(int posX, int posY);
}
