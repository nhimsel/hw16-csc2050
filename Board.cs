using System;

public class Board
{
    // checker short representation 0 is unfilled. -1 for black. 1 for red
    // 0 is bottom of board, 6 is top
    // 0 is right, 7 is left
    private Result [,] board;
    private short rows=6;
    private short cols=7;

    public Board()
    {
        this.board=new Result[cols,rows];
        //initialize the board
        for(int c=0;c<cols;c++)
        {
            for(int r=0;r<rows;r++)
            {board[c,r]=new Result();}
        }
    }

    /*
     * attempts to place a piece in a column. 
     * takes in the column and colour of the piece.
     * returns a Result with info about the move
     */
    public Result MakeMove(short col, short colour)
    {
        Result r=new Result();
        // if the column is a legal value and at least one space on the board is open
        if ((col>=0&&col<cols)&&(board[(int)col,(int)rows-1].colour==0))
        {
            //make the move
            for (int i=0; i<rows; i++)
            {
                if (board[(int)col,i].colour!=0)
                {
                    //fill out Result
                    r.legal=true;
                    r.row=(short)i;
                    r.col=col;
                    r.colour=colour;  
                    //fill in place on board
                    board[(int)col,i]=r;
                    break;
                }
            }
        }
        //else the move is false (default for r)
        return r;
    }

    /*
     * check if there is a sequence of 4 moves including the piece at the passed row and column 
     * returns a bool indicating whether there is a winner
     */
    public bool Winner(short col,short row)
    {
        short ct=1;
        short lc=0;
        //check horizontally
        for(int c=col-4;c<col+4;c++) 
        {
            //ensure the columns tested exist
            if((c>=0)&&(c<cols))
            {
                lc=board[c,(int)row].colour;
                short nc=board[c+1,(int)row].colour;
                //update count if next piece is same colour
                if((lc==nc)&&(nc!=0)){ct++;}
                //check for winner
                if(ct>=4){return true;}
            }
        }
        ct=1;
        lc=0;
        //check vertically
        for(int r=row-4;r<row+4;r++) 
        {
            //ensure the rows tested exist
            if((r>=0)&&(r<rows))
            {
                lc=board[(int)col,r].colour;
                short nc=board[(int)col,r+1].colour;
                //update count if next piece is same colour
                if((lc==nc)&&(nc!=0)){ct++;}
                //check for winner
                if(ct>=4){return true;}
            }
        }
        ct=1;
        lc=0;
        //check horizontally (top left to bottom right)
        for(int c=col-4;c<col+4;c++)
        {
            //ensure teh colums tested exist
            if((c>=0)&&(c<cols))
            {
                for(int r=row-4;r<row+4;r++)
                {
                    //ensure the rows tested exist
                    if((r>=0)&&(r<rows))
                    {
                        lc=board[c,r].colour;
                        short nc=board[c+1,r+1].colour;
                        //update count if next piece is same colour
                        if((lc==nc)&&(nc!=0)){c++;}
                        //check for winner
                        if(c>=4){return true;}
                    }
                }
            }
        }
        ct=1;
        lc=0;
        //check horizontally (top right to bottom left)
        for(int c=col-4;c<col+4;c++)
        {
            //ensure the columsn tested exist
            if((c>=0)&&(c<cols))
            {
                for(int r=row+4;r>=row-4;r--)
                {
                    //ensure the rows testsed exist
                    if((r>=0)&&(r<rows))
                    {
                        lc=board[c,r].colour;
                        short nc=board[c+1,r-1].colour;
                        //update count if next piece is same colour
                        if((lc==nc)&&(nc!=0)){c++;}
                        //check for winner
                        if(c>=4){return true;}
                    }
                }
            }
        }
        //no winner
        return false;
    }

    /*
     * prints the board to console
     */
    public void Display()
    {
        for(int r=rows-1;r>=0;r--)
        {
            for(int c=0;c<cols;c++)
            {
                Manager.PrintStuff(board[c,r].colour+" ");
            }
            Manager.PrintStuff("\n");//newline after each row
        } 
    }
}
