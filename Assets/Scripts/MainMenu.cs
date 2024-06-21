using Godot;
using System;

public partial class MainMenu : Control
{
	private PackedScene game_scene = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/Game.tscn");
	private PackedScene strat_scene = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/StrategyMenu.tscn");
	private GameState gs;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gs = GameState.get_game_state();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_new_game(){
		gs.reset();
		GetTree().ChangeSceneToPacked(game_scene);
	}

	private void _on_exit(){
		GetTree().Quit();
	}

	private void _on_strategy(){
		gs.clear_strategies();
		GetTree().ChangeSceneToPacked(strat_scene);
	}
}
