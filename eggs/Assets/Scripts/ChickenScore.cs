using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChickenScore : MonoBehaviour
{
    ChickenManager chickenManager;

    private float score;
    private float multiplier;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text multiplierText;

    private void OnEnable()
    {
        ChickenManager.Instance.AddScore += IncrementScore;
        ChickenManager.Instance.UpdateMult += UpdateMult;
    }

    private void OnDisable()
    {
        ChickenManager.Instance.AddScore -= IncrementScore;
        ChickenManager.Instance.UpdateMult -= UpdateMult;
    }

    private void IncrementScore()
    {
        score = score + (1 * multiplier);
        UpdateUI();
    }

    private void UpdateMult()
    {
        //missCount++;
        UpdateUI();
    }

    private void Start()
    {
        chickenManager = FindAnyObjectByType<ChickenManager>();
    }

    private void Update()
    {
        multiplier = chickenManager.mult;
    }

    private void UpdateUI()
    {
        scoreText.text = $"Score: {score}";
        multiplierText.text = $"Multiplier: {multiplier}";
    }
}
