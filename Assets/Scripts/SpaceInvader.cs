using Godot;
using System;
using System.Diagnostics;

public partial class SpaceInvader : CharacterBody2D
{
    private AnimatedSprite2D a_sprite;

    private GameState gs;

    private readonly PackedScene shield_pu = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/Shield_PU.tscn");

    public override void _Ready()
    {
        gs = GameState.get_game_state();
        a_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        a_sprite.Play("default");
    }

    public void kill(){
        gs.add_kill();
        float rand = new RandomNumberGenerator().Randf();
        if(rand < 0.05f){
            Area2D shield_instance = shield_pu.Instantiate<Area2D>();
            shield_instance.Position = GlobalPosition;
            GetTree().Root.CallDeferred("add_child",shield_instance);
        }
        GetNode<Aliens>("../..").remove_path(GetNode<PathFollow2D>(".."));
		GetNode("..").QueueFree();
	}
}
