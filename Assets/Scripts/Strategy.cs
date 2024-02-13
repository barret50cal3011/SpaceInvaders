using Godot;
using System;
using System.Diagnostics;

public partial class Strategy : Node2D
{
	bool is_mouse_ontop= false;
	public enum Type{
		None = 0,
		Haste = 1,
		FireRate = 2,
		Shield = 3
	}

	[Export] private Type type;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Sprite2D>("Sprite2D").Frame = (int)type;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsMouseButtonPressed(MouseButton.Left) && is_mouse_ontop){
			Position = GetViewport().GetMousePosition();
		}
	}

	private void _on_mouse_entered(){
		is_mouse_ontop = true;
	}

	private void _on_mouse_exited(){
		is_mouse_ontop = false;
	}
}
