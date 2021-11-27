using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Timer : MonoBehaviour
{
    public float tiempo = 0.0f;
    public Text textTimer = null;
    private float reset = 0.0f;
    public UnityEvent<bool> EvaluarEvent;
    private bool stopTimer = false;
    void Start(){
        reset = tiempo;
    }

    void Update()
    {
        if(!stopTimer) tiempo -= Time.deltaTime;
        //textTimer.text = "Time " + tiempo;
        textTimer.text = "Time: "+TimeFormater(tiempo);
        if(tiempo <= 0.0f){
            Reset();
            EvaluarEvent.Invoke(false);
        }
    }

    public void Reset()
    {
        tiempo = reset;
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
