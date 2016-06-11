using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public int timer = 30;
    public Canvas canvas;
    public Text timerText;

	void Start () {
        StartCoroutine(CountdownRoutine());
       // GameObject.FindObjectOfType<GameController>().setRunning(false);

    }

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TriggerStart();
        }

    }

    private void TriggerStart()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }

   public IEnumerator CountdownRoutine()
    {
        int i = 1;
        while (timer > i)
        {
            timer -= 1;
            timerText.text = timer.ToString();
            yield return new WaitForSeconds(1);
        }
        SwitchCanvas();
        GameObject.FindObjectOfType<GameController>().setRunning(true);
        timer = 30;
    }

   public void SwitchCanvas()
    {
        canvas.gameObject.SetActive(!canvas.gameObject.active);
    }

    public void StartCountdown()
    {
        StartCoroutine(CountdownRoutine());
    }

}
