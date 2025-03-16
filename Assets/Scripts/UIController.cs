using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;


    private void Awake()
    {
        instance = this;
    }

    public Slider explvlSlider;
    public TMP_Text expLvlText;
    public TMP_Text currLvl;
    public TMP_Text life;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLife(int newVal)
    {
        life.text = "Life : " + newVal;
    }

    public void UpdateExperience(int currentExp, int levelExp, int currentLevel)
    {
        explvlSlider.maxValue = levelExp;
        explvlSlider.value = currentExp;

        expLvlText.text = currentExp + "/" + levelExp;

        currLvl.text = "Level : " + currentLevel;

    }
}
