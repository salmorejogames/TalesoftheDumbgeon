using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	private Dialogue dialogue;
	public static bool running = false;
    public bool click = false;
    private string basePath = "DialogueFiles";
    public string language = "/ESP";
    public string character = "/ElCuervillo";
    private TextAsset[] path = new TextAsset[12];// = "Assets/Dialogues/Spanish.txt";
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
        path[0] = Resources.Load(basePath + language + character + "/Intro") as TextAsset;
        path[1] = Resources.Load(basePath + language + character + "/SegundoEncuentro") as TextAsset;
        path[2] = Resources.Load(basePath + language + character + "/TercerEncuentroAbuesqueleto") as TextAsset;
        path[3] = Resources.Load(basePath + language + character + "/TercerEncuentroBanana") as TextAsset;
        path[4] = Resources.Load(basePath + language + character + "/TercerEncuentroPelusa") as TextAsset;
        path[5] = Resources.Load(basePath + language + character + "/TercerEncuentroCerebro") as TextAsset;
        path[6] = Resources.Load(basePath + language + character + "/CuartoEncuentroPrimera") as TextAsset;
        path[7] = Resources.Load(basePath + language + character + "/CuartoEncuentroSegunda") as TextAsset;
        path[8] = Resources.Load(basePath + language + character + "/QuintoEncuentro") as TextAsset;
        path[9] = Resources.Load(basePath + language + character + "/SextoEncuentro") as TextAsset;
        path[10] = Resources.Load(basePath + language + character + "/SeptimoEncuentro") as TextAsset;
        path[11] = Resources.Load(basePath + language + character + "/NovenoOctavoEncuentro") as TextAsset;
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
        /*
         * var listToReturn = new List<string>();
        var arrayString = ta.text.Split('\n');
        foreach (var line in arrayString)
        {
            listToReturn.Add(line);
        }
         */
        string[] arrayString = path[dialoguePath].text.Split('\n');
        for(int i = 0; i<arrayString.Length; i++)
        {
            aux = arrayString[i];
            auxAux = aux.Split('|');
            dialogue.name.Add(auxAux[0]);
            dialogue.sentences.Add(auxAux[1]);
            dialogue.face.Add(auxAux[2]);
            /*
            faceAux = Int32.Parse(auxAux[2]);
            Debug.Log(faceAux);
            dialogue.face.Add(faceAux);*/
        }
        //reader.Close();
        //TriggerDialogue();
    }

    public void TriggerDialogue()
	{
        if (running ==false)        //if((PauseMenu.gameIsPaused == false) && (running ==false))
        {
            //Cursor.SetCursor(cursorInteracted, Vector2.zero, CursorMode.ForceSoftware);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
				
	}

    public void CinematicTriggerDialogue()
    {
        if (running == false)        //if((PauseMenu.gameIsPaused == false) && (running ==false))
        {
            //Cursor.SetCursor(cursorInteracted, Vector2.zero, CursorMode.ForceSoftware);
            FindObjectOfType<CinematicDialogueManager>().StartDialogue(dialogue);
        }

    }

    public void UpdatePath(int newDialoguePath)
    {
        string aux;
        string[] auxAux;
        dialogue = new Dialogue();
        dialoguePath = newDialoguePath;
        string[] arrayString = path[dialoguePath].text.Split('\n');
        for (int i = 0; i < arrayString.Length; i++)
        {
            aux = arrayString[i];
            auxAux = aux.Split('|');
            dialogue.name.Add(auxAux[0]);
            dialogue.sentences.Add(auxAux[1]);
            dialogue.face.Add(auxAux[2]);
        }
        //reader.Close();
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
