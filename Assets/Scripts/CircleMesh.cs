using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMesh : MonoBehaviour
{
    public GameObject myPrefab; 
    private SphereCollider mySphereCollider; 
   
    private int counter = 0; 

    public GameObject Greenhouse; 
    [SerializeField] private GameObject PressEnter;

    //private Vector3 InitialPos; 
    // private float TotalDist = 0; 

    // Start is called before the first frame update
    private void Start()
    {
        //InitialPos = transform.position; 

        mySphereCollider = GetComponent<SphereCollider>();   

        Greenhouse.SetActive(false); 
        PressEnter.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
       ControlledMeshAccess();
    }

    void MeshAccess() {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vv = mesh.vertices;
        int kVerts=vv.Length; 
        kVerts = 25; 
        for (int i=0; i<kVerts; ++i) {
        Debug.Log(vv[i]); 
        Instantiate(myPrefab, vv[i], Quaternion.identity); 
        }     
    }

    private void ControlledMeshAccess() {
       //var time = 1; // Increment this variable every frame to see the rotation
        var objectCount = 25;
        
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vv = mesh.vertices;
        int kVerts=vv.Length; 
        kVerts = 25;
     
        if (Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Space pressed");
            //var rho = time + i;
            var rho = counter % 2; 
            var phi = 2 * Mathf.PI * counter/ objectCount;
            var x = (float)(mySphereCollider.radius * Mathf.Sin(phi) * Mathf.Cos(rho));
            var z = (float)(mySphereCollider.radius * Mathf.Sin(phi) * Mathf.Sin(rho));
            var y = (float)(mySphereCollider.radius * Mathf.Cos(phi));
                
                //Color color = new Color(0.0f, 0.0f, 1.0f);  
                if (counter<=objectCount){
                    Instantiate(myPrefab, vv[counter], Quaternion.identity);
                    counter ++; 
                    // have a counter that increments each time you press spacebar and then instantiate each time you press spacebar then increment the counter
                    //because when it gets run each frame counter will reset back to 0
                }

                else if (counter>25){
                    Debug.Log("Thank you for playing:)");

                    Greenhouse.SetActive(true); 
                    PressEnter.SetActive(true);
                }

        }
          
    }

}
