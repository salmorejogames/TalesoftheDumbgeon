using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	private Dialogue dialogue;
	public static bool running = false;
    public bool click = false;
    private string basePath = "Assets/DialogueFiles";
    public string language = "/ENG";
    public string character = "/Adan";
    private string[] path = new string[12];// = "Assets/Dialogues/Spanish.txt";
    public int linea = 0;
    private int faceAux;
    /*
    public Texture2D cursorNone;
    public Texture2D cursorDetected;
    public Texture2D cursorInteracted;
    */
    public int dialoguePath = 0;


    public void Start()
    {
        path[0] = basePath + language + character + "/Intro.txt";
        path[1] = basePath + language + character + "/SegundoEncuentro.txt";
        path[2] = basePath + language + character + "/TercerEncuentroAbuesqueleto.txt";
        path[3] = basePath + language + character + "/TercerEncuentroBanana.txt";
        path[4] = basePath + language + character + "/TercerEncuentroPelusa.txt";
        path[5] = basePath + language + character + "/TercerEncuentroCerebro.txt";
        path[6] = basePath + language + character + "/CuartoEncuentroPrimera.txt";
        path[7] = basePath + language + character + "/CuartoEncuentroSegundo.txt";
        path[8] = basePath + language + character + "/QuintoEncuentro.txt";
        path[9] = basePath + language + character + "/SextoEncuentro.txt";
        path[10] = basePath + language + character + "/SeptimoEncuentro.txt";
        path[11] = basePath + language + character + "/OctavoEncuentro.txt";
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
        //Addressables.LoadAsset<TextAsset>(path[0]);
        StreamReader reader = new StreamReader(path[dialoguePath]);
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

    public void UpdatePath(int newDialoguePath)
    {
        string aux;
        string[] auxAux;
        dialogue = new Dialogue();
        dialoguePath = newDialoguePath;
        StreamReader reader = new StreamReader(path[dialoguePath]);
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
