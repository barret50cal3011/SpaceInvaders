using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class HpBar : Control
{
	private readonly PackedScene shield = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/Shield.tscn");

	private GameState gs;
	private Array<TextureRect> hp;

	public override void _EnterTree()
	{
		base._EnterTree();
		
	}

	public override void _Ready()
	{
		base._Ready();
		gs = GameState.get_game_state();
		hp = new Array<TextureRect>();
		for(int i = 0; i < gs.get_lifes(); i++){
			hp.Add(shield.Instantiate<TextureRect>());
			AddChild(hp[i]);
			Vector2 new_pos = new Vector2(50 + (i*100), 50);
			hp[i].Position = new_pos;
		}
	}

	public void render(int i_lives){
		if(i_lives < hp.Count){
			while(i_lives != hp.Count){
				remove_shield();
			}
		}else if(i_lives > hp.Count){
			while(i_lives != hp.Count){
				add_shield();
			}
		}
	}

	public void add_shield(){
		hp.Add(shield.Instantiate<TextureRect>());
		AddChild(hp.Last());
		Vector2 new_pos = new Vector2(50 + ((hp.Count - 1)*100), 50);
		hp.Last().Position = new_pos;
	}

	public void remove_shield(){
		hp.Last().QueueFree();
		hp.RemoveAt(hp.Count - 1);
	}

    public void render_score(int i_score){
        GetNode<Label>("Score").Text = "" + i_score;
    }
}
