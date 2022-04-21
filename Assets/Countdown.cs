using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public int currentTime;
    private void Start()
    {
        currentTime = 0;
    }
    public void updateTimer()
    {
        currentTime++;
        this.transform.gameObject.GetComponent<Text>().text = $"Timer : {60 - currentTime}";
    }
}
