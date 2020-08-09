public interface IGameManager
{
	void QuitApplication();

	void SetPlayerControl(IPlayerControlManager playerControl);
	void MovePlayerUp();
	void MovePlayerDown();
	void MovePlayerLeft();
	void MovePlayerRight();
}