using Godot;
using Godot.Collections;
using System;

public class StrategieHolder
{

	Array<Strategy.Type> strategies;

	public StrategieHolder(){
		strategies = new Array<Strategy.Type>();
	}

	public void add_strategie(Strategy.Type i_strategie){
		strategies.Add(i_strategie);
	}

	public void remove_strategie(Strategy.Type i_strategie){
		strategies.Remove(i_strategie);
	}

	public void clear_strategies(){
		strategies.Clear();
	}

	public bool check_strat(Strategy.Type strat){
		return strategies.Contains(strat);
	}

	public void print_strategies(){
		GD.Print("Strategies:");
		foreach(Strategy.Type strat in strategies){
			GD.Print(strat);
		}
	}
}
