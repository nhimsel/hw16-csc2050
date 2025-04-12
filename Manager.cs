using System;

public class Manager
{
    private Board board;

    public Manager()
    {
        this.board=new Board();
    }

    /*
     * start the game of connect 4. currently unfinished
     */
    public void Play()
    {
        //following code is from Litman, modified to fit my existing project
        System.Random rand=new System.Random();
        //make 42 random moves to guarantee a full game 
        for(int i=0;i<42;i++)
        {
            Result r;
            do
            {
                short col=(short)rand.Next(0,7);
                short colour=(short)Math.Pow(-1,(i%2));
                PrintStuff("move:"+i+"\ntry: col"+col+" for colour:"+colour+"\n");
                this.board.Display();
                r=this.board.MakeMove(col,colour);
            }
            while(!r.legal);
            //we have a successful move
            //check to see if that move won the game
            if(this.board.Winner(r.col,r.row))
            {
                //someone won
                PrintStuff(board.GetPlayerAt(r.col,r.row)+" won on move "+i+"\n");
                //end the game
                break;
            }
        }
        PrintStuff("final board:\n");
        this.board.Display();
    }

    // just prints stuff. a macro to allow me to easily modify how everything prints.
    public static void PrintStuff(string s){Console.Write(s);}
}
