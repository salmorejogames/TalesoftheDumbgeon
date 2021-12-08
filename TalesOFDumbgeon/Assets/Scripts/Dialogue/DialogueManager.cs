using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour {

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;

	public Animator animator;
	public IsometricMove player;

	private Queue<string> names;
	private Queue<string> sentences;
	private Queue<string> faces;

	/*
	public Sprite spriteUp;
	public Sprite spriteThink;
	public Sprite spriteDown;*/

	GameObject Comentarios;

	bool written = false; //Correction
	int clicks; //Correction

	// Use this for initialization
	void Start () {
		names = new Queue<string>();
		sentences = new Queue<string>();
		faces = new Queue<string>();
		Comentarios = GameObject.Find("Comentarios");
	}

	public void StartDialogue(Dialogue dialogue)
	{
		clicks = -1;

		DialogueTrigger.running = true;
		player.DisableInputController();

		animator.SetBool("IsOpen", true);

		//nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string name in dialogue.name)
		{

			names.Enqueue(name);
		}

		foreach (string sentence in dialogue.sentences)
		{
			Debug.Log("Ahhhhhhh: " + dialogue.sentences);
			sentences.Enqueue(sentence);
		}

		foreach (string face in dialogue.face)
		{
			Debug.Log("EEEEEhhhhhhh: " + dialogue.face);
			faces.Enqueue(face);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		clicks++;
		if (written == false)
		{
			if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

			string name = names.Dequeue();
			string sentence = sentences.Dequeue();
			string face = faces.Dequeue();
			StopAllCoroutines();
			StartCoroutine(TypeSentence(name, sentence, face));
			//StartCoroutine(ChangeSentence());
			
		}
	}

	IEnumerator TypeSentence (string name, string sentence, string face)
	{
		Debug.Log("Estoy en TypeSentence");
		written = true;
		nameText.text = name;
		//nameText.text = "";
		/*
		if(name == "Prota")
		{
			Comentarios.GetComponent<Image>().sprite = spriteUp;
		}
		else if(name == "Pensamiento")
		{
			Comentarios.GetComponent<Image>().sprite = spriteThink;
		}
		else
		{
			Comentarios.GetComponent<Image>().sprite = spriteDown;
			nameText.text = name;
		}*/

		//FindObjectOfType<FaceChanger>().UpdateFace(Int32.Parse(face));

		dialogueText.text = "";
		float contTemp = 0;
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			if(clicks < 1)
			{
				yield return new WaitForSeconds(0.02f);
				contTemp = contTemp + 0.02f;
			}
			else
			{
				yield return new WaitForSeconds(0.02f);
				contTemp = contTemp + 0.02f;
			}
			
		}
		clicks = -1;
		written = false;
		//yield return new WaitForSeconds(2.8f - contTemp);
		//DisplayNextSentence();
	}

	IEnumerator ChangeSentence()
	{
		Debug.Log("patata");
		yield return new WaitForSeconds(2.0f);
		Debug.Log("zanahoria");
		DisplayNextSentence();
	}

	void EndDialogue()
	{
		nameText.text = "";
		dialogueText.text = "";
		animator.SetBool("IsOpen", false);
		DialogueTrigger.running = false;
		player.EnableInputController();
	}

}
