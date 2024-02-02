using Godot;
using System;
using System.Diagnostics;
using System.Linq;

public partial class GameState : Node
{
    private static GameState gs;

    private HpBar hp_hud;

    private int lives;
    private int max_lives;
    private int points;

    public override void _EnterTree()
    {
        base._EnterTree();
        if(gs == null){
            lives = 3;
            max_lives = 3;
            points = 0;
            gs = this;
        }
    }

    public override void _Ready()
    {
        base._Ready();
        hp_hud = (HpBar)GetTree().GetFirstNodeInGroup("HUD");
    }

    public static GameState get_game_state(){
        return gs;
    }

    public int get_lifes(){
        return lives;
    }

    public int hit(){
        lives--;
        if(lives == 0){
            Debug.WriteLine("Game Over");
        }
        reload_lives();
        return  lives;
    }

    public void add_kill(){
        points += 32;
        hp_hud.render_score(points);
    }

    public void add_shield(){
        if(lives < max_lives)
        {
            lives++;
            reload_lives();
        }
    }

    public void reload_lives(){
        hp_hud.render(lives);
    }
}
