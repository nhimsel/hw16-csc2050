using System;

public class Manager
{
    private Board board;

    public Manager()
    {
        this.board = new Board();
    }

    /*
     * start the game of connect 4. currently unfinished
     */
    public void Play()
    {
        //following code is from Litman, modified to fit my existing project
        System.Random rand=new System.Random();
        //make 10 random moves for testing
        for(int i=0;i<10;i++)
        {
            this.board.Display();
            Result r;
            do
            {
                short col=(short)rand.Next(0,7);
                short colour=(short)Math.Pow(-1,(i%2));
                PrintStuff("try: col"+col+" for colour:"+colour+"\n");
                r=this.board.MakeMove(col,colour);
            }
            while(!r.legal);
            //we have a successful move
            //check to see if that move won the game
            if(this.board.Winner(r.col,r.row))
            {
                //someone won
            }
        }
        PrintStuff("finished test\n");
    }

    public static void PrintStuff(string s){Console.Write(s);}
}
