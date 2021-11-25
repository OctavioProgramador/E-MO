using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuntuacionManager : MonoBehaviour
{    
    // Start is called before the first frame update
    [SerializeField] private Text puntuacion = null;
    [SerializeField] private Button salir = null;
    [SerializeField] private Button reiniciar = null;

    void Start()
    {
        puntuacion.text = "Tu puntuacionn es: " + PlayerPrefs.GetInt("puntacion");
        if(salir != null) salir.onClick.AddListener(() => SceneManager.LoadScene(0));
        if(reiniciar != null) reiniciar.onClick.AddListener(() => SceneManager.LoadScene(0));
    }

}
