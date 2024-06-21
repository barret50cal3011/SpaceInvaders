using Godot;
using System;

public partial class StrategyMenu : Node2D
{

	private readonly PackedScene main_menu_scene = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/MainMenu.tscn");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_back_to_menu(){
		GetTree().ChangeSceneToPacked(main_menu_scene);
	}
}
