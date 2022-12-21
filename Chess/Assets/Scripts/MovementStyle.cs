using UnityEngine;

public abstract class MovementStyle : MonoBehaviour
{
    [SerializeField] private Piece piece;
    private GameManager gameManager;
    public Piece Piece { get { return piece; } }
    public GameManager GameManager { get { return gameManager; } }

    public virtual void Start() {
        piece = GetComponent<Piece>();
        gameManager = FindObjectOfType<GameManager>();
    }
    public abstract bool IsMovementAllowed(int posX, int posY);
}
