using Godot;
using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

public partial class Bullet : RigidBody2D
{
    private float life = 0.5f;
    private float time = 0f;

    public override void _Process(double delta){
        time += (float)delta;
        if(time > life){
            QueueFree();
        }
    }
    
    private void _on_collition(Node body){
        if(body.IsInGroup("Alien")){
            ((SpaceInvader)body).kill();
        }
        QueueFree();
    }

    private void _on_not_visible(){
        QueueFree();
    }
}
