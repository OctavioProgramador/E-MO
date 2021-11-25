using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BotonesPuntuacion : MonoBehaviour
{
    // Start is called before the first frame update
    public void Salir(){
        SceneManager.LoadScene(0);
    }
    public void Reiniciar(){
        SceneManager.LoadScene(0);
    }
}
