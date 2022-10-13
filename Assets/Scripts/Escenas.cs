using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class Escenas : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tipoMov;
    GameObject Text;

    public static Escenas escena;
    public string[] mov = { "Basico", "Fisicas", "Fuerzas" };
    public int Index;
    // Start is called before the first frame update
    private void Awake()
    {
        if (escena == null)
        {
            escena = this;
        }
        else
        {
            Destroy(this);
        }

        Text = GameObject.Find("TipoMov");
        tipoMov = Text.GetComponent<TextMeshProUGUI>();

    }
    void Start()
    {
        //tipoMov.text = mov[Index];
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        int Index = scene.buildIndex;

        tipoMov.text = mov[Index];

        if (Input.GetKeyUp(KeyCode.C))
        {
            if (Index == 2)
            {
                Index = -1;
            }

            cargarEscena(Index+1);
        }

        if (Input.GetKeyUp("escape"))
        {
            Application.Quit();
        }
    }

    public void cargarEscena(int esc)
    {
        SceneManager.LoadScene(esc);
        /* index:
         * Basico 0
         * Fisicas 1
         * Fuerza 2
         */
    }
}
