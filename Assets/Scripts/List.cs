using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 

public class List : MonoBehaviour
{
    private List<Transform> Positions = new List<Transform>();
    private GameObject[] cubes;  

    [SerializeField] private float ObjectSpeed;
    [SerializeField] private GameObject PressShift; 

    private int NextPosIndex; 
    private Transform NextPos;

    private float moveVertical;
    private float moveHorizontal;

    private AudioSource BeeSound; 

    private string Content;

    //[SerializeField] private GameObject Bee;

    void Start() {
       PressShift.SetActive(false);
       //Bee.SetActive(false);

       BeeSound = GetComponent<AudioSource>();
       BeeSound.Stop(); 
        
    }
 
    void Update()
    {

        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");
        CreateList(); 
        Look();
        
          
    }

    void CreateList() {
        if (Input.GetKeyDown(KeyCode.Return)){
            BeeSound.Play();
            cubes = GameObject.FindGameObjectsWithTag("Cube");
            //MoveObject(); 
           
            for (int j = 0; j<cubes.Length; j++){
                if(cubes[j].tag == "Cube") {
                    Positions.Add(cubes[j].transform); 
                    //Positions.Add(FinalPos);
                    NextPos = Positions[0];
                    Debug.Log(Positions[j].position);

                    string path = Application.dataPath + "/DistanceLog.txt";
                    Content = "The final positions are " + Positions[j].position + "\n"; 
                    File.AppendAllText(path, Content);

                    
                }
               StartCoroutine(TimerCoroutine());
            }
            
        } 
        for (int i = 0; i<Positions.Count; i++){
                //Bee.SetActive(true);
                MoveObject();
        }  
    }

    void MoveObject(){
        if(transform.position == NextPos.position){
            NextPosIndex++; 

            if(NextPosIndex >= Positions.Count){
                NextPosIndex = 0; 
            }
            NextPos = Positions[NextPosIndex]; 
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);
            transform.LookAt(NextPos);
        }
    }

    void Look() {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 newPosition = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition * ObjectSpeed * Time.deltaTime, Space.World);
    }

    IEnumerator TimerCoroutine() {

        yield return new WaitForSeconds(30f);
        PressShift.SetActive(true);
        
    }

    // private void CreateText() {
    //     string path = Application.dataPath + "/DistanceLog.txt";
    //     Content = "The final positions are " + TotalDist + "\n" + "Distance Vector " + DistanceVector + "\n\n"; 
    //     File.AppendAllText(path, Content);
    // }

}
