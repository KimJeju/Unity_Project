using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
   
   public GameObject Target;

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
            this.transform.position = Target.transform.position;
        }
    }
}
