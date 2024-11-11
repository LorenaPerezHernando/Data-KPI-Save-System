using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI t_points;
    GameOn s_ManagergameOn;
    [SerializeField] TextMeshProUGUI t_countDown;
    CountDown s_ManagerLv;
    public GameObject panelNextLevel;

    public TextMeshProUGUI t_pointsPanelFinal;
    public TextMeshProUGUI t_totalPoints;
    void Awake()
    {
        s_ManagergameOn = FindObjectOfType<GameOn>();
        s_ManagerLv = FindObjectOfType<CountDown>();
    }

    private void Start()
    {
        panelNextLevel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Textpoints();
        CambiarColor();

        t_countDown.text = string.Format("{0:00}", s_ManagerLv.seconds);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitButton();
        }
    }

    void Textpoints()
    {
        t_points.text = "Points: " + s_ManagergameOn.points.ToString();
    }

    void CambiarColor() 
    {
        if(s_ManagergameOn.points > 0)
            t_points.color = Color.green;

        if (s_ManagergameOn.points < 0)
            t_points.color = Color.red;

        if(s_ManagergameOn.points == 0)
            t_points.color = Color.white;
    }

    void ExitButton()
    {
        Application.Quit();
    }

    


}
