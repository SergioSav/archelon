using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	[SerializeField] private TMP_Text _loadingProgressLabel;
	private AsyncOperation _loadingProcess;

	private void Start()
	{
		_loadingProgressLabel.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (_loadingProcess != null)
		{
			var progressValue = Mathf.Round(Mathf.Clamp01(_loadingProcess.progress / 0.9f) * 100);
			_loadingProgressLabel.text = $"loading ... {progressValue}%";
		}
	}

	public void OnStartButtonClick()
	{
		_loadingProgressLabel.gameObject.SetActive(true);
		StartCoroutine(LoadGameScene());
	}

	private IEnumerator LoadGameScene()
	{
		_loadingProcess = SceneManager.LoadSceneAsync("Scenes/LevelScene");

		if (!_loadingProcess.isDone)
		{
			yield return null;
		}
	}

	public void OnExitButtonClick()
	{
		Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}
}
