using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Orthogonal, DiagonalForward, Diagonal, Forward, ForwardTwoFirstMove, LShape }

    List<MovementStyle> movementStyles = new List<MovementStyle>();

    void Start() {
        GetComponents<MovementStyle>(movementStyles);
    }


    public bool CanIMoveHere(int posX, int posY) {

        

        return false;
    }


}
