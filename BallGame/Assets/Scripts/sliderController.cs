using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class sliderController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    private int levelValue;
    public Slider slider;

    public static sliderController Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        slider = GetComponent<Slider>();
        levelText.text = "Level " + (GetComponent<Slider>().value + 1).ToString();
    }

    public void SelectTheLevel()
    {
        levelText.text = "Level " + (GetComponent<Slider>().value + 1).ToString();
        levelValue = Mathf.RoundToInt(GetComponent<Slider>().value);
        PlayerPrefs.SetInt("Level", levelValue + 1);

    }

    private void Update()
    {
        if (Mathf.RoundToInt(GetComponent<Slider>().value) == 0)
        {
            PlayerPrefs.SetInt("Level", 2);
        }
        else
        {
            PlayerPrefs.SetInt("Level", levelValue + 1);
        }
    }
}
