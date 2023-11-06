using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI hud, msgVitoria;
    public int restantes;   
    public AudioClip clipMoeda, clipVitoria;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        restantes = FindObjectsOfType<Moeda>().Length;
        hud.text = $"Moedas restantes: {restantes}";
        TryGetComponent(out source);
    }

    public void SubtrairMoedas(int valor)

{
    
	restantes = restantes - valor;
    source.PlayOneShot(clipMoeda);
	hud.text = $"Moedas restantes: {restantes}";
    

	if(restantes <= 0)
{
    hud.text = " ";
    
    source.Stop();

    source.PlayOneShot(clipVitoria);

	msgVitoria.text = "Parabéns!!!";
}

}


    // Update is called once per frame
    void Update()
    {
        
    }
}
