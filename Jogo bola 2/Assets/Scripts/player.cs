using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

 public int velocidade = 10;
 private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
     TryGetComponent(out rb);   
    }

    // Update is called once per frame
    void Update()
    {
     float inputHorizontal = Input.GetAxis("Horizontal");
     float inputVertical = Input.GetAxis("Vertical");

     rb.AddForce(new Vector3(inputHorizontal,0,inputVertical)* velocidade );  

     if (transform.position.y <= - 10){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
    }
}
