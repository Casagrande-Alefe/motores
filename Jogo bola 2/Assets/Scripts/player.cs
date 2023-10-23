using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

 public int velocidade = 10;
 public int forcaPulo = 7;
 private Rigidbody rb;
 private AudioSource source;
 public AudioClip clipPulo, clipMoeda;
 public bool noChao;

    // Start is called before the first frame update
    void Start()
    {
     TryGetComponent(out rb);   
     TryGetComponent(out source);
    }

    void OnCollisionEnter(Collision col){
      if(col.gameObject.tag == "chao"){
         noChao = true;
      }
    }

    // Update is called once per frame
    void Update()
    {
     float inputHorizontal = Input.GetAxis("Horizontal");
     float inputVertical = Input.GetAxis("Vertical");

     rb.AddForce(new Vector3(inputHorizontal,0,inputVertical)* velocidade );  

     if(Input.GetKeyDown(KeyCode.Space) && (noChao == true)){
         source.PlayOneShot(clipPulo);
         rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
         noChao = false;
     }

     if (transform.position.y <= - 10){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
    }
}
