using Godot;
using System;
using System.Diagnostics;

public partial class Shield_PU : Area2D
{
    [Export]
    private double fall_Speed;

    private GameState gs;

    public override void _Ready()
    {
        base._Ready();
        gs = GameState.get_game_state();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Vector2 new_pos = new(Position.X , Position.Y + (float)(fall_Speed* delta));
        Position = new_pos;
    }
    private void _on_body_entered(Node2D body){
        if(body.IsInGroup("Player")){
            gs.add_shield();
            QueueFree();
        }
    }
}
