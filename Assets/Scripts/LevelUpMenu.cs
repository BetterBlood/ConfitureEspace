using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public static LevelUpMenu instance;

    public int[] choices = new int[3];
    public Button button1;
    public Button button2;
    public Button button3;
    
    private void Awake()
    {
        instance = this;
    }

    public GameObject levelUpMenuUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        choices[0] = 0;
        choices[1] = 1;
        choices[2] = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void BonusChoiceMenu()
    {
        Time.timeScale = 0f;
        levelUpMenuUI.SetActive(true);
        choices[0] = Random.Range(0, 6);
        choices[1] = Random.Range(0, 6);
        while (choices[1] == choices[0]) choices[1] = Random.Range(0, 6);
        while (choices[2] == choices[0] || choices[2] == choices[1]) choices[2] = Random.Range(0, 6);

    }

    public void ButtonChoice1()
    {
        // ICI AUSSI BRYAN ET JEREMIAH
    }

    public void ButtonChoice2()
    {
        // ICI AUSSI BRYAN ET JEREMIAH
    }

    public void ButtonChoice3()
    {
        // ICI AUSSI BRYAN ET JEREMIAH
    }
}
