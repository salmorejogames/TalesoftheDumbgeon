using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	private Dialogue dialogue;
	public static bool running = false;
    public bool click = false;
    private string basePath = "Assets/Dialogues/txt";
    public string language = "/ENG";
    public string character = "/Adan";
    private string[] path = new string[9];// = "Assets/Dialogues/Spanish.txt";
    public int linea = 0;
    private int faceAux;
    /*
    public Texture2D cursorNone;
    public Texture2D cursorDetected;
    public Texture2D cursorInteracted;
    */


    public void Start()
    {
        path[0] = basePath + language + character + "/Intro.txt";
        path[1] = basePath + language + character + "/Fase1Good.txt";
        path[2] = basePath + language + character + "/Fase1Bad.txt";
        path[3] = basePath + language + character + "/Fase2Good.txt";
        path[4] = basePath + language + character + "/Fase2Bad.txt";
        path[5] = basePath + language + character + "/Fase3Good.txt";
        path[6] = basePath + language + character + "/Fase3Bad.txt";
        path[7] = basePath + language + character + "/FinalGood.txt";
        path[8] = basePath + language + character + "/FinalBad.txt";
        //Cursor.SetCursor(cursorNone, Vector2.zero, CursorMode.ForceSoftware);
        /*
        dialogue = new Dialogue();
        StreamReader reader = new StreamReader(path);
        for(int i = 0; i<linea; i++)
        {
            reader.ReadLine();
        }
        string aux = reader.ReadLine();
        string[] auxAux = aux.Split('|');
        dialogue.name = auxAux[0];
        dialogue.sentences.Add(auxAux[1]);
        reader.Close();
        linea++;
        */
        string aux;
        string[] auxAux;
        dialogue = new Dialogue();
        //Resources.Load
        //Addressables.LoadAsset<GameObject>("AssetAddress");
        Addressables.LoadAsset<TextAsset>(path[0]);
        StreamReader reader = new StreamReader(path[0]);
        linea = Int32.Parse(reader.ReadLine());
        Debug.Log(linea);
        for(int i = 0; i<linea; i++)
        {
            aux = reader.ReadLine();
            auxAux = aux.Split('|');
            dialogue.name.Add(auxAux[0]);
            dialogue.sentences.Add(auxAux[1]);
            dialogue.face.Add(auxAux[2]);
            /*
            faceAux = Int32.Parse(auxAux[2]);
            Debug.Log(faceAux);
            dialogue.face.Add(faceAux);*/
        }
        reader.Close();
        //TriggerDialogue();
    }

    public void TriggerDialogue()
	{
        if(running ==false)        //if((PauseMenu.gameIsPaused == false) && (running ==false))
        {
            //Cursor.SetCursor(cursorInteracted, Vector2.zero, CursorMode.ForceSoftware);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
				
	}

    public void UpdatePath(int newPath)
    {
        string aux;
        string[] auxAux;
        dialogue = new Dialogue();
        StreamReader reader = new StreamReader(path[newPath]);
        linea = Int32.Parse(reader.ReadLine());
        Debug.Log(linea);
        for (int i = 0; i < linea; i++)
        {
            aux = reader.ReadLine();
            auxAux = aux.Split('|');
            dialogue.name.Add(auxAux[0]);
            dialogue.sentences.Add(auxAux[1]);
            dialogue.face.Add(auxAux[2]);
        }
        reader.Close();
    }
	private void OnMouseDown()
	{
        TriggerDialogue();
    }

    private void OnMouseEnter()
    {
        //if (gameObject.CompareTag("Selectable"))
        //{
            if (running == false)      //((PauseMenu.gameIsPaused == false) && (running == false))
            {
                //Cursor.SetCursor(cursorDetected, Vector2.zero, CursorMode.ForceSoftware);
                click = true;
            }
        //}
    }

    private void OnMouseExit()
    {
        //if (gameObject.CompareTag("Selectable"))
        //{
            //Cursor.SetCursor(cursorNone, Vector2.zero, CursorMode.ForceSoftware);
            click = false;
        //}
    }
}
