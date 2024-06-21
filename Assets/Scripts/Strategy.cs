using Godot;
using Godot.Collections;
using System;
using System.Collections;
using System.Diagnostics;

public partial class Strategy : Node2D
{
	bool is_mouse_ontop = false;
	public enum Type{
		None = 0,
		Haste = 1,
		FireRate = 2,
		Shield = 3
	}

	[Export] private Type type;

	private bool holding = false;

	private Array<Node2D> near_holders;

	private StrategyGUIHolder holder;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		holder = null;
		near_holders = new Array<Node2D>();
		GetNode<Sprite2D>("Sprite2D").Frame = (int)type;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsMouseButtonPressed(MouseButton.Left) && is_mouse_ontop){
			Position = GetViewport().GetMousePosition();
			holding = true;
			if(holder != null){
				holder.remove_strat(this);
				holder = null;
			}
		}else if(holding){
			holding = false;
			calc_nearest_holder();
		}
	}

	public Type get_type(){
		return type;
	}

	private void calc_nearest_holder(){
		if(near_holders.Count > 0){
			Node2D nearest = near_holders[0];
			float distance = Position.DistanceTo(nearest.Position);
			foreach(Node2D holder in near_holders){
				float new_distance = Position.DistanceTo(holder.Position);
				if(new_distance < distance){
					nearest = holder;
					distance = new_distance;
				}
			}
			Position = nearest.Position;
			add_strat(nearest);
		}
	}

	private void add_strat(Node2D i_holder){
		StrategyGUIHolder gui_holder = (StrategyGUIHolder)i_holder;
		gui_holder.add_strat(this);
		holder = gui_holder;
	}

	private void _on_area_2d_area_exited(Area2D area){
		if(area.GetParent().IsInGroup("StratHolder")){
			near_holders.Remove((Node2D)area.GetParent());
		}
	}

	private void _on_mouse_entered(){
		is_mouse_ontop = true;
	}

	private void _on_mouse_exited(){
		is_mouse_ontop = false;
	}

	public void set_strat(Type strat){
		type = strat;
	}

	private void _on_area_2d_area_entered(Area2D area){
		if(area.GetParent().IsInGroup("StratHolder")){
			near_holders.Add((Node2D)area.GetParent());
		}
	}
}
