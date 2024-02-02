using Godot;
using Godot.Collections;
using System;
using System.Diagnostics;

public partial class Aliens : Path2D
{
	[Export]
	private double speed = 200;
	private Array<PathFollow2D> paths;

	private readonly PackedScene alien = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/space_invader.tscn");
	public override void _Ready()
	{
		paths = new Array<PathFollow2D>();
		Array<Node> nodes = GetChildren();
		foreach(Node node in nodes){
			paths.Add((PathFollow2D)node);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		for(int i = 0; i < paths.Count; i++){
			paths[i].Progress += (float)(speed * delta);
		}
	}

	private void _on_timer_timeout(){
		add_alien();
	}

	private void add_alien(){
		CharacterBody2D alien_instance = alien.Instantiate<CharacterBody2D>();
		PathFollow2D path = new()
		{
			Progress = 0f,
			Rotates = false
		};
		path.AddChild(alien_instance);
		AddChild(path);
		paths.Add(path);
	}
}
