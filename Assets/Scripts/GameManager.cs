using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

    public Text timerText;
    public Text addressText;
    public int timer = 30;
    public GameObject panel;

	void Start () {
        StartCoroutine(CountdownRoutine());
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

    IEnumerator CountdownRoutine()
    {
        int i = 1;
        while (timer > i)
        {
            timer -= 1;
            timerText.text = timer.ToString();
            yield return new WaitForSeconds(1);
        }
        timerText.gameObject.SetActive(false);
        addressText.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
      
    }

}
