using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Linq;

public class HighScore : MonoBehaviour {

    public float time;

    public Text scoreText;
    // Use this for initialization
    void Start () {
       
	}

    void SetScoreText(float time)
    {
        scoreText.text = time.ToString();
    }

}
