using Godot;
using Godot.Collections;
using System;

public class StrategieHolder
{
	public enum Strategie{
        Speed,
        FireRate
    }

	Array<Strategie> strategies;

	public StrategieHolder(){
		strategies = new Array<Strategie>();
	}

	public void add_strategie(Strategie i_strategie){
		strategies.Add(i_strategie);
	}

	public void remove_strategie(Strategie i_strategie){
		strategies.Remove(i_strategie);
	}

	public void clear_strategies(){
		strategies.Clear();
	}

	public bool check_strat(Strategie strat){
		return strategies.Contains(strat);
	}
}
