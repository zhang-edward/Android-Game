using UnityEngine;
using System.Collections;

public abstract class BoardTile : MonoBehaviour {

	public Board board;
	protected Animator anim;

	// how many points this tile is worth (for the enemy tiles)
	public int pointValue;

	public AudioClip click;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public void animate()
	{
		anim.SetTrigger ("Hit");
		SoundManager.instance.RandomizeSfxBoard(click);
	}

	public virtual void Hit()
	{
		ScoreManager.instance.GPGIncrementButtonsPressed();
		if (Application.loadedLevelName.Equals("Tutorial"))
			TutorialGameManager.instance.score += pointValue;
		else
			GameManager.instance.score += pointValue;
	}
}