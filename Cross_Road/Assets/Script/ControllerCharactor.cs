using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCharactor : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager gameManager;

    void OnTriggerEnter(Collider col) {
        if(col.tag == "DeadLine")
        {
            gameManager.Result();
        }
    }
}
