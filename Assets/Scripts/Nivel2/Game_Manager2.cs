using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Game_Manager2 : MonoBehaviour
{
    [SerializeField] private AudioClip m_correctSound = null;
    [SerializeField] private AudioClip m_incorrectSound = null;
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField] private Color m_incorrectColor = Color.black;
    [SerializeField] private float m_waitTime = 0.0f;
    
    public Timer timer = null;
        
    private QuizDB m_quizDB = null;
    private QuizUI m_quizUI = null;
    private AudioSource m_audioSource = null;

    private int score = 0;
    [SerializeField] private int intentos = 3;

    private void Start()
    {
        m_quizDB = GameObject.FindObjectOfType<QuizDB>();
        m_quizUI = GameObject.FindObjectOfType<QuizUI>();
        m_audioSource = GetComponent<AudioSource>();
        NextQuestion();
    }
    public void NextQuestion()
    {
       timer.StartTimer();
        m_quizUI.Construtc(m_quizDB.GetRandom(), GiveAnswer);
    }

    private void GiveAnswer(OptionButton optionButton)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton));
    }

    private IEnumerator GiveAnswerRoutine(OptionButton optionButton)
    {
        if(m_audioSource == null){
            Debug.Log("m_audioSource es null");            
        }
        if(optionButton == null){
            Debug.Log("optionButton es null");            
        }
        if (m_audioSource.isPlaying)
            m_audioSource.Stop();
        
        m_audioSource.clip = (bool)optionButton.Option.correct ? m_correctSound : m_incorrectSound;
        
        optionButton.SetColor((bool)optionButton.Option.correct ? m_correctColor : m_incorrectColor);

        m_audioSource.Play();

        timer.StopTimer();
        timer.Reset();

        yield return new WaitForSeconds(m_waitTime);

        Evaluar((bool)optionButton.Option.correct);

    }

    //Metodo que se ejecuta cuando el timer llega a 0
    public void GiveAnswerTimerEnd(){
        if(m_audioSource == null){
            Debug.Log("m_audioSource es null");            
        }
        
        if (m_audioSource.isPlaying)
            m_audioSource.Stop();
        
        m_audioSource.clip =  m_incorrectSound;

        m_audioSource.Play();

        timer.StopTimer();
        timer.Reset();
        Evaluar(false);
    }

    public void Evaluar(bool eleccion){
       
        if (eleccion){
            score++;
            m_quizUI.m_score.text =  "Score: "+score.ToString();
            NextQuestion();
        }
        else
        {
            intentos--;
            if(intentos == 0){
                PlayerPrefs.SetInt("puntuacion", score);
                GameOver();
            }else{
                NextQuestion();
            }
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(1);
    }


}
