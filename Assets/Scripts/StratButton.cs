using Godot;
using System;

public partial class StratButton : Button
{
	[Export] private Strategy.Type strat;

	private readonly PackedScene strat_scene = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/Strategy.tscn");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(Icon is AtlasTexture atlas){
			Vector2 size = new Vector2((float)16.0, (float)16.0);
			atlas.Region = new Rect2(new Vector2(16 * (int)strat, 0), size);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	private void _on_pressed(){
		Strategy strat_instance = strat_scene.Instantiate<Strategy>();
		strat_instance.Position = GetViewport().GetMousePosition();
		strat_instance.set_strat(strat);
		GetParent().AddChild(strat_instance);
	}
}
