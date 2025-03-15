using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ExperienceLevelController : MonoBehaviour
{

    public static ExperienceLevelController instance;

    private void Awake()
    {
      instance = this;
    }

    public int currentExperience;

    public ExpPickup pickup;

    public List<int> expLevels;
    public int currentLevel = 1, levelCount = 50;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        while(expLevels.Count < levelCount)
        {
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count - 1] * 1.1f));
                
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetExp(int amountToGet)
    {
        currentExperience += amountToGet;

        // level up
        if(currentExperience >= expLevels[currentLevel])
        {
            LevelUp();
        }

        UIController.instance.UpdateExperience(currentExperience, expLevels[currentLevel], currentLevel);
    }

    private void LevelUp()
    {
        currentExperience -= expLevels[currentLevel];
        currentLevel++;

        LevelUpMenu.instance.BonusChoiceMenu();

        if (currentLevel >= expLevels.Count)
        {
            currentLevel = expLevels.Count - 1;
        }
    }

}
