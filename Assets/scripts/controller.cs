using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Android;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    private List<List<GameObject>> grid;
    [SerializeField]
    private RectTransform gridPanel;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Text buttonText;
    [SerializeField]
    private InputField Xinput;
    [SerializeField]
    private InputField Yinput;
    [SerializeField]
    private Text Generation;
    [SerializeField]
    private Text Population;
    [SerializeField]
    private GameObject prototypeCell;
    #region privatevariables
    private int width = 25;
    private int height = 25;
    private bool runSimulation;
    private int defaultSeed = 80085;
    #endregion

    public void SetDefault() 

    {
    }
    public void RunSimulation()
    {
        runSimulation = !runSimulation;
        Debug.Log(buttonText.GetType());
      if (runSimulation)
        {
            buttonText.gameObject.GetComponent<Text>().text = "Stop";
        }
        else
        {
            buttonText.gameObject.GetComponent<Text>().text = "Start";
        }
    }

    public void SetX()
    {
        if (int.TryParse(Xinput.text, out int x))
        {
            width = x;
            Debug.Log(x);
            setGrid();
        }
    }

    public void SetY()
    {
        if (int.TryParse(Yinput.text, out int y))
        {
            height = y;
            Debug.Log(y);
            setGrid();
        }
    }

    public void setGrid(bool useDefault = false)
    {
        // 1 spawn cells at grid width and height
        if (grid != null)
        {
            foreach(var r in grid)
            {
                foreach(var c in r)
                {
                    // resets grid
                    GameObject.Destroy(c);
                }
            }
        }
        grid = new List<List<GameObject>>();
        for (int i = 0; i < width; ++i)
        {
            grid.Add(new List<GameObject>(height));
            for (int j = 0; j < height; ++j)
            {
                grid[i].Add(null);
            }
        }
        Color defaultColor = useDefault ? new Color(0, 0, 0) : Color.white;
        float cellWidth = gridPanel.rect.width / width;
        float cellHeight = gridPanel.rect.height / height;
        if (useDefault)
        {
            UnityEngine.Random.InitState(defaultSeed);
        }

        int cellCounter = 0;

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                GameObject c = GameObject.Instantiate(prototypeCell);
                c.transform.parent = gridPanel;
                c.transform.position = new Vector3(-cellWidth + i * cellWidth, -1 + j * cellHeight);// ooopppaaaaa!
                c.SetActive(true);

                grid[i][j] = c;
                if (!useDefault)
                {
                    c.GetComponent<cell>().colChange(Color.white);
                    c.GetComponent<cell>().Dead = true;
                }
                else
                {
                    if (cellCounter < 66)
                    {
                        if (UnityEngine.Random.Range(0, 2) == 1)
                        {
                            c.GetComponent<cell>().colChange(Color.black);
                            c.GetComponent<cell>().Dead = false;
                            cellCounter++;
                        }
                    }
                }
            }
        }

    }


    void Awake()
    {
        runSimulation = false;
        setGrid();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
