struct Limit
{
  //the border limits are called because they are used at line 9-12
    public float Top, Bottom, AI_Side, Player_Side;

  //so that they can be used in other scripts and the Inspector
    public Limit (float top, float bottom, float ai_side, float player_side)
    {
        Top = top;
        Bottom = bottom;
        AI_Side = ai_side;
        Player_Side = player_side;
    }
}
