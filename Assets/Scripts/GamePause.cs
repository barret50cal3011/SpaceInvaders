using Godot;
using System;

public partial class GamePause : Control
{
	private readonly PackedScene main_menu = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/MainMenu.tscn");


	private void _on_resume_button_up(){
		GD.Print("Resume button pressed");
		GetTree().Paused = false;
		QueueFree();
	}

	private void _on_exit_button_up()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToPacked(main_menu);
	}
}
