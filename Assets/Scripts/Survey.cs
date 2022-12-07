using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Survey : MonoBehaviour
{
    Toggle m_Toggle;
    public Text m_Text;

    // //public GameObject[] Answers; 
    // //public GameObject Toggler; 

    // //public InputField mainInputField;

    private void Start(){
        Toggles(); 
        //Debug.Log(mainInputField.GetComponent<InputField>().text);
    }

    public void ToggleValueChanged(Toggle change)
    {
        m_Text.text =  "Yes is " + m_Toggle.isOn;
        Debug.Log( m_Text.text);
    }

    void Toggles() {
        //Fetch the Toggle GameObject
        m_Toggle = GetComponent<Toggle>();

        //Add listener for when the state of the Toggle changes, to take action
        m_Toggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(m_Toggle);
            });
    }

}
