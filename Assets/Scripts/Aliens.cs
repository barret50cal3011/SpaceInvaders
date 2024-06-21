using Godot;
using Godot.Collections;
using System;
using System.Diagnostics;

public partial class Aliens : Path2D
{
	private GameState gs;

	[Export]
	private double speed = 100;
	private Array<PathFollow2D> paths;

	private readonly PackedScene alien = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/space_invader.tscn");

	public override void _Ready()
	{
		gs = GameState.get_game_state();
		paths = new Array<PathFollow2D>();
		Array<Node> nodes = GetChildren();
		foreach(Node node in nodes){
			if (node is PathFollow2D){
				paths.Add((PathFollow2D)node);
			}
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		for(int i = 0; i < paths.Count; i++){
			paths[i].Progress += (float)(speed * delta * (2 + (float)gs.get_diffeculty()/4));
		}
	}

	private void _on_timer_timeout(){
		if(paths.Count < calc_max_alines()){
			add_alien();
		}
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

	public void remove_path(PathFollow2D i_path){
		paths.Remove(i_path);
	}

	private int calc_max_alines(){
		return 16 + (2 * gs.get_diffeculty());
	}
}
