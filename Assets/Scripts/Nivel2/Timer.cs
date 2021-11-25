using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Timer : MonoBehaviour
{
    public float tiempo = 0.0f;
    public Text textTimer = null;
    private float reset = 0.0f;
    // Update is called once per frame
    public UnityEvent<bool> EvaluarEvent;
    private bool stopTimer = false;
    void Start(){
        reset = tiempo;
    }

    void Update()
    {
        //while(!stopTimer){tiempo -= Time.deltaTime;}
        tiempo -= Time.deltaTime;
        textTimer.text = "Time " + tiempo;
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

}
