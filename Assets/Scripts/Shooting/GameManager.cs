using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public Text pointsText;
    private int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        pointsText.text = "Points: " + points;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetPoints(int points) {
        this.points = points;
        pointsText.text = "Points: " + points;
        Debug.Log("Points: " + points);
    }

    public void AddPoints(int points)
    {
        SetPoints(this.points += points);
        
    }

    public int GetPoints() {
        return this.points;
    }
}
