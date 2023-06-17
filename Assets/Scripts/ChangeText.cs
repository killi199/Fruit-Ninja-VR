using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textComponent; // Private Referenz auf die Text-Komponente des Text-GameObjects
    public int Lives = 5, Score = 0;

    public void updateScore(int amount)
    {
        this.Score += amount;
        this.ChangeTextContent("Lives: " + Lives + "\nScore: " + Score);
    }

    public void updateLives(int amount)
    {
        this.Lives += amount;
        this.ChangeTextContent("Lives: " + Lives + "\nScore: " + Score);
    }

    private void Start()
    { 
        ChangeTextContent("Lives: " + Lives + "\nScore: " + Score);
    }

    // Ändern des Texts
    public void ChangeTextContent(string newText)
    {
        textComponent.text = newText;
    }
}
