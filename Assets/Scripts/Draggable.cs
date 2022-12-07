using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 

public class Draggable : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mouseZCoord;
    private Vector3 prefabObject;
    //public GameObject cube; 
    private Renderer renderer; 

    public Material pink;
    public Material yellow;
    
    private Vector3 InitialPos; 
    private Vector3 DistanceVector; 
    private float TotalDist = 0; 

    private string Content; 

    private Vector3 PickedUp; 
    private Vector3 Dropped; 

    //private List<Vector3> droppedPositions = new List<Vector3>(); 

    private void Start() {
        InitialPos = transform.position; 
    }

    void OnMouseDown()
    {
        prefabObject = gameObject.transform.position;
        mouseZCoord = Camera.main.WorldToScreenPoint(prefabObject).z;
        // Store offset = gameobject world pos - mouse world pos
        mouseOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        transform.GetComponent<MeshRenderer>().material = pink;

        PickedUp = transform.position; 
        Debug.Log("Picked up at: " + PickedUp);
    }

    void OnMouseUp()
    {
        transform.GetComponent<MeshRenderer>().material = yellow;
        
        DistanceVector= transform.position - InitialPos; 
        float DistanceThisFrame = DistanceVector.magnitude;
        TotalDist+=DistanceThisFrame; 
        InitialPos = transform.position;  

        Vector3 currentCube = GameObject.FindGameObjectWithTag("Cube").transform.position;
        Debug.Log("the distance moved is " + DistanceVector);
        Debug.Log("Distance moved: " + TotalDist);

        Dropped = transform.position; 
         Debug.Log("Dropped at: " + Dropped);
        //Content = "Distance moved: " + TotalDist + "\n"; 

        CreateText(); 

    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition; 
        // z coordinate of game object on screen
        mousePoint.z = mouseZCoord;  
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    { 
        transform.position = GetMouseAsWorldPoint() + mouseOffset;
    }

    private void CreateText() {
        string path = Application.dataPath + "/DistanceLog.txt";
        // if (!File.Exists(path)) {
            // File.WriteAllText(path, "DistanceLog \n\n");

            Content = "Distance moved: " + TotalDist + "\n" + "Distance Vector " + DistanceVector + "\n\n"; 

            File.AppendAllText(path, Content);
        //}
    }

}
