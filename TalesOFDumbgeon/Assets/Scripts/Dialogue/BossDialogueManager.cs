using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BossDialogueManager : MonoBehaviour {

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;

	public Animator animator;
	public IsometricMove player;
	public Weapon weapon;
	public PlayerAnimationController playerAnimator;
	public GameObject cards;
	public GameObject habilidadesButtons;

	private JojoMamaloBehaviour jojo;

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

	public void StartDialogue(Dialogue dialogue, JojoMamaloBehaviour jojo)
	{
		this.jojo = jojo;
		clicks = -1;

		DialogueTrigger.running = true;
		player.DisableInputController();
		weapon.SetOnDialogue(true);
		playerAnimator.SetOnDialogue(true);
		cards.SetActive(false);
		habilidadesButtons.SetActive(false);
		

		animator.SetBool("IsOpen", true);

		//nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string name in dialogue.name)
		{
			Debug.Log("Name: " + name);
			names.Enqueue(name);
		}

		foreach (string sentence in dialogue.sentences)
		{
			Debug.Log("Sentence: " + sentence);
			sentences.Enqueue(sentence);
		}

		foreach (string face in dialogue.face)
		{

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
		float speed = 0.02f;
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			if (clicks < 1)
			{
				yield return new WaitForSeconds(speed / 0.8f);
				contTemp = contTemp + (speed / 0.8f);
			}
			/*
			else
			{
				yield return new WaitForSeconds(speed / 1.4f);
				contTemp = contTemp + (speed / 1.4f);
			}*/

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
		weapon.SetOnDialogue(false);
		playerAnimator.SetOnDialogue(false);
		cards.SetActive(true);
		habilidadesButtons.SetActive(true);
		PlayerPrefs.SetInt("Jojomamalos", PlayerPrefs.GetInt("Jojomamalos", 0) + 1);
		jojo.StartCombat();
	}

}
