using Godot;
using System;

public partial class BoardTile : Node2D
{
	private int x_pos;
	private int y_pos;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void set_pos(int i_x, int i_y){
		x_pos = i_x;
		y_pos = i_y;
	}

	public int[] get_pos(){
		int[] res = {x_pos, y_pos};
		return res;
	}
}
