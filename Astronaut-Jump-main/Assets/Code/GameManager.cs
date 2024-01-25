using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	[SerializeField] private TextMeshProUGUI textScore;

	public int Score
	{
		get => _score;
		set
		{
			if (value > _score)
			{
				_score = value;
				textScore.SetText(_score.ToString());
			}
		}
	}
	public GameObject panel;

	private int _score;





	private void Awake()
	{ 
		 Instance = this;
		 panel.SetActive(false);
		 Time.timeScale=1;
	}

	public void GameOver()
	{ 
		panel.SetActive(true);
		Debug.Log("Game Over");
		Time.timeScale = 0;
	}

	 public void PlayAgain()
	{ 
		panel.SetActive(false);
		Debug.Log("Game Start"); 
			//Time.timeScale=1;
	    SceneManager.LoadSceneAsync(1);  
		Debug.Log("Load "); 
	}
	  public void QuitButton()
    {
        Application.Quit();
    }
}