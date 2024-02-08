using Godot;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public partial class Tank : CharacterBody2D
{
	enum State{
		Idle,
		Moving,
		Fireing
	}

	private State current_state;
	[Export] private int speed = 400;
	private bool moving;
	private AnimatedSprite2D a_sprite;

    private readonly PackedScene bullet = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/Bullet.tscn");

    [Export] private double cooldown = 0.5;
    private double timer = 0;

	private GameState gs;

	public override void _EnterTree()
	{
		current_state = State.Idle;
		moving = false;
		a_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite");
	}

    public override void _Ready()
    {
        base._Ready();
		gs = GameState.get_game_state();
    }

    public override void _Process(double delta)
	{
		if(moving && current_state != State.Moving && current_state != State.Fireing){
			current_state = State.Moving;
			a_sprite.Play("Moving");
		}else if(!moving && current_state != State.Idle && current_state != State.Fireing){
			current_state = State.Idle;
			a_sprite.Play("Idle");
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		float x_direction = Input.GetAxis("move_left", "move_right");
		if(x_direction != 0 && !moving){
			moving = true;
		}else if(x_direction == 0 && moving){
			moving = false;
		}

        
        Velocity = new Vector2(x_direction, 0) * speed;
        
		MoveAndSlide();

        timer += delta;
        if(Input.IsActionJustPressed("fire") && cooldown <= timer){
            fire();
            timer = 0;
        }
	}

    private void fire(){
        Node2D bullet_instance = bullet.Instantiate<Node2D>();
        bullet_instance.Position = Position + new Vector2(0, -25);
        GetParent().AddChild(bullet_instance);
		current_state = State.Fireing;
		a_sprite.Play("Fire");
    }

	private void _on_animated_sprite_animation_looped(){
		if(current_state == State.Fireing){
			a_sprite.Play("Idle");
			current_state = State.Idle;
		}
	}

	private void _on_collition(Node2D body){
		if(body.IsInGroup("Alien")){
			body.QueueFree();
			gs.hit();
		}
	}
}
