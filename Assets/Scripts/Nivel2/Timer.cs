using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Timer : MonoBehaviour
{
    public float time = 0.0f;
    private float reset = 0.0f;
    public Text textTimer = null;
    public UnityEvent<bool> unityEvent;
    private bool stopTimer = false;
    void Start(){
        //Cuando el tiempo llegue a 0 reiniciara en la cantidad de la variables
        //reset, por esto en la instanciación se guarda el valor de time en reset
        reset = time;
    }

    void Update()
    {
        if(!stopTimer) time -= Time.deltaTime;
        textTimer.text = "Time: "+TimeFormater(time);
        if(time <= 0.0f){
            Reset();
            //Aquí se invoca el método que cambia a la siguiente pregunta
            //En este caso se envia falso porque el hecho de que el tiempo
            //acabe reduce los intentos
            unityEvent.Invoke(false);
        }
    }

    public void Reset()
    {
        time = reset;
    }

    public void StartTimer()
    {
        stopTimer = false;
    }

    public void StopTimer()
    {
        stopTimer = true;
    }

    public string TimeFormater(float floatTime){
        string stringTime;
        int intSeconds = (int) floatTime;
        float floatMiliseconds = floatTime - (float)intSeconds;
        int intMiliseconds =  (int)(floatMiliseconds * 100);
        stringTime = intSeconds + ":"+intMiliseconds;
        return stringTime;
    }
}
