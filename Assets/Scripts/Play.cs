using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    
    public void PressButton() {
        Destroy((GetComponent<Canvas>()).gameObject);
    }
}
