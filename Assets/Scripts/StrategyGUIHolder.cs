using Godot;
using System;

public partial class StrategyGUIHolder : Node2D
{
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

	public void add_strat(Strategy strat){
		gs.add_strategie(strat);
	}

	public void remove_strat(Strategy strat){
		gs.remove_strategie(strat);
	}
}
