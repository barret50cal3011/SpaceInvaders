using Godot;
using Godot.Collections;
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

    private PackedScene gameOverScene;

    private int difficulty;

    private StrategieHolder strategies;
    public override void _EnterTree()
    {
        strategies = new StrategieHolder();
        //strategies.add_strategie(StrategieHolder.Strategie.Speed);
        //strategies.add_strategie(StrategieHolder.Strategie.FireRate);
        base._EnterTree();
        if(gs == null){
            lives = 3;
            max_lives = 3;
            points = 0;
            difficulty = 1;
            gs = this;
        }
        gameOverScene = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/GameOverScreen.tscn");
    }

    public static GameState get_game_state(){
        return gs;
    }

    public int get_lifes(){
        return lives;
    }

    public void hit(){
        lives--;
        if(lives == 0){
            gameOver();
        }
        reload_lives();
    }

    public void add_kill(){
        points += 32;
        hp_hud.render_score(points);
        if(new RandomNumberGenerator().Randf() < 0.25){
            difficulty++;
        }
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

    public int get_points(){
        return points;
    }

    private void gameOver(){
        GetTree().ChangeSceneToPacked(gameOverScene);
    }

    public void reset(){
        points = 0;
        lives = max_lives;
        
    }

    public void set_hp_bar(HpBar i_bar){
        hp_hud = i_bar;
    }

    public int get_diffeculty(){
        return difficulty;
    }

    public bool check_strat(Strategy.Type i_strategy){
        return strategies.check_strat(i_strategy);
    }

    public void add_strategie(Strategy i_strategy){
        strategies.add_strategie(i_strategy.get_type());
    }

    public void remove_strategie(Strategy i_strategy){
        strategies.remove_strategie(i_strategy.get_type());
    }

    public void clear_strategies(){
        strategies.clear_strategies();
    }

    public void print_strategies(){
        strategies.print_strategies();
    }
}
