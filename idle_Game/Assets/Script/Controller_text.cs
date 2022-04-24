using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_text : MonoBehaviour
{

    float Move_Time = 0.0f;

    public void init() 
    {
        Move_Time = 0f;
        this.gameObject.SetActive(true);
    }

    void Active_Off()
    {
        this.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Move_Time < 1.0f)
        {
            Move_Time += Time.deltaTime;
            this.transform.position += Vector3.up * 0.5f;
        }else{
            Active_Off();
        }
    }
}
