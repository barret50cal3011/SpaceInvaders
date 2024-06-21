using Godot;
using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

public partial class StratBoard : Node2D
{
	[Export] private int width;
	[Export] private int height;

	private BoardTile[] board;
	private readonly PackedScene tile_scene = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/BoardTile.tscn");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		board = new BoardTile[width * height];

		for(int i = 0; i < width * height; i++){
			BoardTile new_tile = tile_scene.Instantiate<BoardTile>();
			int pos_x = i % width;
			int pos_y = i / width;
			new_tile.set_pos(pos_x, pos_y);
			new_tile.Position = new Vector2(
				40 + (80 * pos_x),
				40 + (80 * pos_y)
			);
			AddChild(new_tile);
			board[i] = new_tile;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
