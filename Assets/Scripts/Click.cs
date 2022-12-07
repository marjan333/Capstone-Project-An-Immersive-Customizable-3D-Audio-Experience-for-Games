 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = transform.position;
            //clickPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f,10f));

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit; 

            if(Physics.Raycast(ray, out hit)){
                clickPosition = hit.point; 
            }

            Debug.Log("click position: " + clickPosition);

        }
    }
    
}

