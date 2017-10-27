﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButton : MonoBehaviour 
{
	public void LoadLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}