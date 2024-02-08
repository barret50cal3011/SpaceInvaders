using Godot;
using System;

public partial class GameOverScreen : Control
{
	private PackedScene game_scene = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/Game.tscn");
	private PackedScene main_menu = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/MainMenu.tscn");

	private GameState gs;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		gs = GameState.get_game_state();
		Label score = GetNode<Label>("Score");

		score.Text = "" + gs.get_points();
	}

	private void _on_play_again(){
		gs.reset();
		GetTree().ChangeSceneToPacked(game_scene);
	}

	private void _on_main_menu(){
		GetTree().ChangeSceneToPacked(main_menu);
	}
}
