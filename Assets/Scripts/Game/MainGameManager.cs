public class MainGameManager : IGameManager
{
	private IPlayerControlManager _playerControlManager;

	public void QuitApplication()
	{
		UnityEngine.Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}


#region PlayerControl
	public void SetPlayerControl(IPlayerControlManager playerControl)
	{
		_playerControlManager = playerControl;
	}

	public void MovePlayerUp()
	{
		_playerControlManager.MoveUp();
	}

	public void MovePlayerDown()
	{
		_playerControlManager.MoveDown();
	}

	public void MovePlayerLeft()
	{
		_playerControlManager.MoveLeft();
	}

	public void MovePlayerRight()
	{
		_playerControlManager.MoveRight();
	}
#endregion
}
