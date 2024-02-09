using Godot;
using Godot.Collections;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class StrategieHolder
{
	public enum Strategie{
        Speed,
        FireRate
    }

	public Dictionary<Strategie, int> price = new()
    {
		{Strategie.Speed, 1},
		{Strategie.FireRate, 1}
	};

	//Dictionarie holds the strategy that is being used and the amount.
	private Dictionary<Strategie, int> strategy_holder;


	public StrategieHolder(){
		strategy_holder = new();
	}

	public int check_strategy(Strategie i_strat){
		if(strategy_holder.ContainsKey(i_strat)){
			return strategy_holder[i_strat];
		}
		return 0;
	}

	public void set_strategies(Array<Strategie> i_strategies){
		for(int i = 0; i < i_strategies.Count; i++){
			if(strategy_holder.ContainsKey(i_strategies[i])){
				strategy_holder[i_strategies[i]]++;
			}else{
				strategy_holder[i_strategies[i]] = 1;
			}
		}
	}
}
